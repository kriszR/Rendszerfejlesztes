using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Szerver.Models;
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IEnumerable<User>> GetStudents()
        {
            return await _userRepository.Get();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
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

        [HttpPost]
        public async Task<ActionResult<User>> PostBooks([FromBody] User student)
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
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var studentToDelete = await _userRepository.Get(id);
            if (studentToDelete == null)
                return NotFound();

            await _userRepository.Delete(studentToDelete.Id);
            return NoContent();
        }
    }
}
