using Microsoft.AspNetCore.Mvc;
using UniClass.Models;
using UniClass.Services;

namespace UniClass.Controller
{
        [ApiController]
        [Route("api/[controller]")]
        public class MajorController : ControllerBase
        {
            private readonly IUniversityService _universityService;

            public MajorController(IUniversityService universityService)
            {
                _universityService = universityService;
            }

            [HttpGet]
            public async Task<IActionResult> GetMajors()
            {
                var Majors = await _universityService.GetMajorsAsync();
                if (Majors == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, "No Majors in database.");
                }

                return StatusCode(StatusCodes.Status200OK, Majors);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetMajors(Guid id)
            {
                Major Major = await _universityService.GetMajorAsync(id);

                if (Major == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"No Major found for id: {id}");
                }

                return StatusCode(StatusCodes.Status200OK, Major);
            }

            [HttpPost]
            public async Task<ActionResult<Major>> AddMajor(Major Major)
            {
                var dbMajor = await _universityService.AddMajorAsync(Major);

                if (dbMajor == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"{Major.Name} could not be added.");
                }

                return CreatedAtAction("GetMajor", new { id = Major.Id }, Major);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateMajor(Guid id, Major Major)
            {
                if (id != Major.Id)
                {
                    return BadRequest();
                }

                Major dbMajor = await _universityService.UpdateMajorAsync(Major);

                if (dbMajor == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"{Major.Name} could not be updated");
                }

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteMajor(Guid id)
            {
                var Major = await _universityService.GetMajorAsync(id);
                (bool status, string message) = await _universityService.DeleteMajorAsync(Major);

                if (status == false)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, message);
                }

                return StatusCode(StatusCodes.Status200OK, Major);
            }
        }
    
}
