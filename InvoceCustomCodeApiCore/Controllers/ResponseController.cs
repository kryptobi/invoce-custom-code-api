namespace InvoceCustomCodeApiCore.Controllers;

[ApiController]
public class ResponseController: ControllerBase
{
    [HttpGet("core")]
    public IActionResult Get()
    {
        var responseUseCase = (CreateResponseUseCase)HttpContext.Items["CreateResponseUseCase"];
        var response = responseUseCase.Create();

        return Ok(response);
    }
    
    [HttpGet("custom")]
    public IActionResult GetCustom()
    {
        var responseUseCase = (CreateResponseUseCase)HttpContext.Items["CreateResponseUseCase"];
        var response = responseUseCase.Create();

        return Ok(response);
    }
}