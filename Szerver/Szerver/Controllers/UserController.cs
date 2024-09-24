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
        private readonly IUserRepository _studentRepository;

        public UserController(IUserRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Users>> GetStudents()
        {
            return await _studentRepository.Get();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetStudents(int id)
        {
            return await _studentRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Users>> PostBooks([FromBody] Users student)
        {
            var newStudent = await _studentRepository.Create(student);
            return CreatedAtAction(nameof(GetStudents), new { id = newStudent.Id }, newStudent);
        }

        [HttpPut]
        public async Task<ActionResult> PutStudents(int id, [FromBody] Users student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            await _studentRepository.Update(student);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var studentToDelete = await _studentRepository.Get(id);
            if (studentToDelete == null)
                return NotFound();

            await _studentRepository.Delete(studentToDelete.Id);
            return NoContent();
        }
    }
}
