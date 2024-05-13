using System.ComponentModel.DataAnnotations;

namespace Szerver.Models.UserFolder
{
    public class UserDto
    {
        //[EmailAddress]
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserLoginDto : UserDto
    {
    }

    public class UserRegisterDto : UserDto
    {
        public string Name { get; set; }
    }

    public class AuthResponseDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class AddCourseToUserDto
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
    }
}
