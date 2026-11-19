using Game.Api.Models;

namespace Game.Api.Services;

// De service bevat de spellogica. De controller roept deze alleen aan.
public class GameService
{
    // Geeft de algemene informatie over het spel terug
    public GameInfoResponse GetInfo()
    {
        return new GameInfoResponse
        {
            Title = "Dungeon Crawler",
            Description = "Kom levend door de kerker en versla de vijanden onderweg.",
            AmountOfLevels = 10,
            StartHealth = 100
        };
    }
}