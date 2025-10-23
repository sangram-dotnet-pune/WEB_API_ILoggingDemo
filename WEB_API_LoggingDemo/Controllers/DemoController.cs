using Microsoft.AspNetCore.Mvc;

namespace WebAPI_ILoggerDemo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly ILogger<DemoController> _logger;
        public DemoController(ILogger<DemoController> logger)
        {
            _logger = logger;
        }
        [HttpGet("log-sample")]
        public IActionResult LogSample()
        {
            _logger.LogInformation("This is an informational log message from DemoController.");
            _logger.LogWarning("This is a warning log message from DemoController.");
            _logger.LogError("This is an error log message from DemoController.");
            return Ok("Log messages have been recorded. Check your logging output.");
            //return Ok(new[] { "Laptop", "Mouse", "Keyboard" });
        }
    }
}