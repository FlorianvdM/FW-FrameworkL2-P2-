using Microsoft.AspNetCore.Mvc;
namespace Game.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class GameController : ControllerBase
{
    public GameController()
    {

    }

    
    [HttpGet]
    public async void Test()
    {

    }
        
}