using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Szerver.Models;
using Szerver.Models.DtoFolder;
using Szerver.Models.UserFolder;
using Szerver.Repositories;

namespace Szerver.Controllers
{    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository studentRepository)
        {
            _userRepository = studentRepository;
        }

 
        [HttpGet]
        public async Task<IEnumerable<User>> GetStudents()
        {
            return await _userRepository.Get();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetUserById")]
        public async Task<ActionResult<User>> GetStudents(int id)
        {
            return await _userRepository.Get(id);
        }

        [HttpGet("{id}/mycourses")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesForUser(int id)
        {
            var userCourses = await _userRepository.GetCoursesForUser(id);
            if (userCourses == null)
            {
                return NotFound();
            }
            return Ok(userCourses);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<User>> PostUser([FromBody] User student)
        {
            var newStudent = await _userRepository.Create(student);
            return CreatedAtAction(nameof(GetStudents), new { id = newStudent.Id }, newStudent);
        }

        /*[HttpPut]
        public async Task<ActionResult> PutStudents(int id, [FromBody] Users student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            await _userRepository.Update(student);

            return NoContent();
        }*/

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteUserById")]
        public async Task<ActionResult> Delete(int id)
        {
            var studentToDelete = await _userRepository.Get(id);
            if (studentToDelete == null)
                return NotFound();

            await _userRepository.Delete(studentToDelete.Id);
            return NoContent();
        }

        [HttpPost]
        [Route("AddCourseToUser")]
        public async Task<ActionResult<List<GetCourseDto>>> AddCourseToUser(AddCourseToUserDto requestObject)
        {
            var result = await _userRepository.AddCourseToUser(requestObject);

            return Ok(result);
        }
    }
}
