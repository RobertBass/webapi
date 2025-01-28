using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WelcomeController : ControllerBase
{
    IWelcomeService welcomeService;

    public WelcomeController(IWelcomeService welcome)
    {
        welcomeService = welcome;
    }

    //[HttpGet]
    //[Route("welcome")]
    public IActionResult Get()
    {
        return Ok(welcomeService.GetWelcomeMessage());
    }
}