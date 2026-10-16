using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day3HumaVolve.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ILogger<EmployeesController> logger)
        {
            _logger = logger;
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation(
            "Getting employee with ID {EmployeeId}", id);
            if (id <= 0)
            {
                _logger.LogWarning(
                "Invalid employee ID: {EmployeeId}", id);
                 return BadRequest();
            }
            return Ok(new { Id = id, Name = "Ahmed" });
        }
    }
}