using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Szerver.Models;
using Szerver.Models.UserFolder;
using Szerver.Repositories;

namespace Szerver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AccountController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthResponseDto))]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            var response = await _authService.Login(loginDto);
            return Ok(response);
        }

        /*[HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto registerDto)
        {
            User user = _mapper.Map<UserRegisterDto, User>(registerDto);
            _mapper.Map<UserRegisterDto, User>(registerDto);
            await _authService.Register(user, registerDto.Password);
            return Ok();
        }*/
    }
}
