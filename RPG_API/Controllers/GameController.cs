using Game.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Game.Api.Controllers;

// [ApiController] zegt dat dit een API-controller is
// [Route] maakt de basis-URL: api/game (de naam zonder "Controller")
[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly GameService _gameService;

    // Constructor injection: ASP.NET Core geeft hier zelf de GameService mee
    // (dat kan omdat hij in Program.cs is geregistreerd met AddScoped)
    public GameController(GameService gameService)
    {
        _gameService = gameService;
    }

    // GET /api/game/status
    [HttpGet("status")]
    public IActionResult Status()
    {
        // Ok() geeft statuscode 200 terug met dit object als JSON
        return Ok(new { message = "API werkt! Welkom bij de Dungeon Crawler." });
    }

    // GET /api/game/info
    [HttpGet("info")]
    public IActionResult Info()
    {
        // De controller haalt de info op bij de service en stuurt die als JSON terug
        var info = _gameService.GetInfo();
        return Ok(info);
    }
}