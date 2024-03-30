using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoodleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public StudentController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult GetJsonFile()
        {
            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "student.json");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var json = System.IO.File.ReadAllText(filePath);
            return Content(json, "application/json");
        }
    }
}
