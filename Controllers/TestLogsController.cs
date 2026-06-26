using Microsoft.AspNetCore.Mvc;

namespace rest_with_asp_net_10_example.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestLogsController : ControllerBase
{
    private readonly ILogger<TestLogsController> _logger;

    public TestLogsController(ILogger<TestLogsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogTrace("This is a trace log message.");
        _logger.LogDebug("This is a debug log message.");
        _logger.LogInformation("This is an information log message.");
        _logger.LogWarning("This is a warning log message.");
        _logger.LogError("This is an error log message.");
        _logger.LogCritical("This is a critical log message.");
        return Ok("Logs have been generated. Check the console or log files for output.");
    }
}
