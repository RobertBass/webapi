using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WelcomeController : ControllerBase
{
    IWelcomeService welcomeService;

    TaskContext dbcontext;

    public WelcomeController(IWelcomeService welcome, TaskContext db)
    {
        welcomeService = welcome;
        dbcontext = db;
    }

    [HttpGet]
    [Route("welcome")]
    public IActionResult Get()
    {
        return Ok(welcomeService.GetWelcomeMessage());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDB()
    {
        dbcontext.Database.EnsureCreated();
        return Ok("Database created");
    }
}