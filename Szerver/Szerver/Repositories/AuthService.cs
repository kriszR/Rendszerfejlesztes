using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Szerver.Migrations;
using Szerver.Models;
using Szerver.Models.UserFolder;
using Szerver.Roles;

namespace Szerver.Repositories
{
    public interface IAuthService
    {
        Task<AuthResponseDto> Login(UserLoginDto loginDto);
        //Task Register(User user, string password);
    }
    public class AuthService : IAuthService
    {
        private readonly MoodleContext _context;
        private readonly IConfiguration _configuration;
        public AuthService(MoodleContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context; 
        }
        public async Task<AuthResponseDto> Login(UserLoginDto loginDto)
        {
            
            var user = await _context.Users!
                .Include(u => u.Roles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(x => x.UserName.ToLower().Equals(loginDto.UserName.ToLower()))
                ?? throw new Exception("Rossz felhasználónév vagy jelszó");

            CreatePasswordHash(loginDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            if (VerifyPasswordHash(loginDto.Password, user.PasswordHash!, user.PasswordSalt!))
            {
                return new AuthResponseDto
                {
                    UserName = user.UserName,
                    Name = user.Name,
                    Token = GenerateJwtToken(user),
                    IsAdmin = user.Roles.Any(role => role.Role.Name.Equals(DefineRoles.Admin))
                };
            }
            else
            {
                throw new Exception("Rossz felhasználónév vagy jelszó");
            }
        }

        private string GenerateJwtToken(User user/*string email*/)
        {

            List<Claim> claims = new List<Claim>
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.UserName),
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            user.Roles.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role.Role.Name)));

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Token").Value ?? throw new Exception("Token kulcs nincs megadva")));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            /*Console.WriteLine("Generált JWT token:");
            Console.WriteLine(jwt);*/

            return jwt;
        }

        /*public async Task Register(User user, string password)
        {
            if (await UserExists(user.UserName))
            {
                throw new Exception("A felhasználó már létezik");
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            var userRole = await _context.Roles!.FirstOrDefaultAsync(role => role.Name.Equals(DefineRoles.User)) ?? throw new Exception("Nem található a szerepkör");

            await _context.Users!.AddAsync(user);
            await _context.SaveChangesAsync();
            await _context.UserRoles!.AddAsync(new UserRole { UserId = user.Id, RoleId = userRole.Id });
            await _context.SaveChangesAsync();
        }*/

        public async Task<bool> UserExists(string email)
        {
            if (await _context.Users!.AnyAsync(user => user.UserName.ToLower().Equals(email.ToLower())))
                return true;
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
 /*var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("A_titkos_kulcs_szoveg"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddDays(7); // Lejárati idő: 7 nap

            var token = new JwtSecurityToken(
                issuer: "https://yourdomain.com",
                audience: "https://yourdomain.com",
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }*/