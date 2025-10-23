using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace WEB_API_LoggingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerilogDemoController : ControllerBase
    {

        private readonly ILogger<SerilogDemoController> _logger;

        public SerilogDemoController(ILogger<SerilogDemoController> logs)
        {
            _logger = logs;
        }


        [HttpGet("check")]
        public IActionResult CheckLogging()
        {
            _logger.LogInformation("CheckLogging endpoint hit at {time}", DateTime.Now);

            try
            {
                int a = 10;
                int b = 2;
                int c = a / b; // Generates DivideByZeroException
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception occurred while dividing numbers.");
                return StatusCode(500, "Internal Server Error");
            }

            return Ok("Logging test successful!");
        }

        [HttpGet("Test-logging-from-appsettings")]
        public IActionResult TestLogging()
        {
            Log.Verbose("Verbose log example");
            Log.Debug("Debug log example");
            Log.Information("Information log example");
            Log.Warning("Warning log example");
            Log.Error("Error log example");
            Log.Fatal("Fatal log example");

            return Ok("Serilog logging test completed! Check console and Logs folder.");
        }

    }
}
