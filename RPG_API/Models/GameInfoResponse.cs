namespace Game.Api.Models;

// DTO: de gegevens die de API over het spel terugstuurt naar de console
public class GameInfoResponse
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public int AmountOfLevels { get; set; }
    public int StartHealth { get; set; }
}