using Microsoft.AspNetCore.Mvc;

namespace Game.Api.Controllers;

// [ApiController] zegt dat dit een API-controller is
// [Route] maakt de basis-URL: api/game (de naam zonder "Controller")
[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    // GET /api/game/status
    [HttpGet("status")]
    public IActionResult Status()
    {
        // Ok() geeft statuscode 200 terug met dit object als JSON
        return Ok(new { message = "API werkt! Welkom bij de Dungeon Crawler." });
    }
}