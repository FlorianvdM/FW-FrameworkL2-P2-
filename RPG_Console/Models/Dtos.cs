namespace RPG_Console.Models;

// DTO's: deze velden moeten overeenkomen met de JSON die de API terugstuurt

// Voor GET /api/game/status
public record StatusDto(string Message);

// Voor GET /api/game/info
public record GameInfoDto(string Title, string Description, int AmountOfLevels, int StartHealth);