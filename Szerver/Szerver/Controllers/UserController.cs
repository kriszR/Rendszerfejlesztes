using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Szerver.Models;
using Szerver.Repositories;

namespace Szerver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository studentRepository)
        {
            _userRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Users>> GetStudents()
        {
            return await _userRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetStudents(int id)
        {
            return await _userRepository.Get(id);
        }

        [HttpGet("{id}/courses")]
        public async Task<ActionResult<IEnumerable<Courses>>> GetCoursesForUser(int id)
        {
            var userCourses = await _userRepository.GetCoursesForUser(id);
            if (userCourses == null)
            {
                return NotFound();
            }
            return Ok(userCourses);
        }

        [HttpPost]
        public async Task<ActionResult<Users>> PostBooks([FromBody] Users student)
        {
            var newStudent = await _userRepository.Create(student);
            return CreatedAtAction(nameof(GetStudents), new { id = newStudent.Id }, newStudent);
        }

        [HttpPut]
        public async Task<ActionResult> PutStudents(int id, [FromBody] Users student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            await _userRepository.Update(student);

            return NoContent();
        }

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
