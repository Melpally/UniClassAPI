using Microsoft.AspNetCore.Mvc;
using UniClass.Models;
using UniClass.Services;

namespace UniClass.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IUniversityService _universityService;

        public StudentController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var Students = await _universityService.GetStudentsAsync();

            if (Students == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No Students in database");
            }

            return StatusCode(StatusCodes.Status200OK, Students);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetStudent(Guid id, bool includeMajors = false)
        {
            Student Student = await _universityService.GetStudentAsync(id, includeMajors);

            if (Student == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Student found with id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, Student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student Student)
        {
            var dbStudent = await _universityService.AddStudentAsync(Student);

            if (dbStudent == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{Student.FullName} could not be added.");
            }

            return CreatedAtAction("GetStudent", new { id = Student.Id }, Student);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateStudent(Guid id, Student Student)
        {
            if (id != Student.Id)
            {
                return BadRequest();
            }

            Student dbStudent = await _universityService.UpdateStudentAsync(Student);

            if (dbStudent == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{Student.FullName} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var Student = await _universityService.GetStudentAsync(id, false);
            (bool status, string message) = await _universityService.DeleteStudentAsync(Student);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, Student);

        }

    }
}
