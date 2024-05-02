using System.ComponentModel.DataAnnotations;

namespace Szerver.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int DegreeId { get; set; }
        public Degree Degree { get; set; }
        /*[EmailAddress]
        public string Email { get; set; }*/
        public List<UserRole> Roles { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
