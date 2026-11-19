using System.Net.Http.Json;
using RPG_Console.Models;

// HttpClient: hiermee stuurt de console requests naar de API
// Let op: de poort moet hetzelfde zijn als die van jouw API
using var client = new HttpClient
{
    BaseAddress = new Uri("http://localhost:5194")
};

// Bij het opstarten kijken of de API bereikbaar is
await ToonStatus(client);

// Hoofdmenu: de lus blijft draaien tot de speler kiest om af te sluiten
bool doorgaan = true;

while (doorgaan)
{
    ToonMenu();
    string? keuze = Console.ReadLine();

    // Kijken wat de speler heeft gekozen
    switch (keuze)
    {
        case "1":
            NieuwSpel();
            break;
        case "2":
            await ToonSpelInfo(client);
            break;
        case "3":
            Console.WriteLine("Tot ziens!");
            doorgaan = false;
            break;
        default:
            // Alles wat geen 1, 2 of 3 is, is een onbekende keuze
            Console.WriteLine("Onbekende keuze, kies 1, 2 of 3.");
            break;
    }
}

// Laat het menu zien
static void ToonMenu()
{
    Console.WriteLine();
    Console.WriteLine("=== DUNGEON CRAWLER ===");
    Console.WriteLine("1. Nieuw spel");
    Console.WriteLine("2. Spelinformatie");
    Console.WriteLine("3. Afsluiten");
    Console.Write("Maak een keuze: ");
}

// Haalt het statusbericht op bij de API (GET /api/game/status)
static async Task ToonStatus(HttpClient client)
{
    try
    {
        // await: wachten tot de API antwoord geeft, daarna JSON omzetten naar StatusDto
        var status = await client.GetFromJsonAsync<StatusDto>("/api/game/status");
        Console.WriteLine(status?.Message);
    }
    catch (HttpRequestException)
    {
        // Gebeurt als de API niet draait
        Console.WriteLine("Kan de API niet bereiken. Staat de API aan?");
    }
}

// Haalt de spelinformatie op bij de API (GET /api/game/info)
static async Task ToonSpelInfo(HttpClient client)
{
    try
    {
        var info = await client.GetFromJsonAsync<GameInfoDto>("/api/game/info");

        if (info == null)
        {
            Console.WriteLine("Geen spelinformatie ontvangen.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine($"--- {info.Title} ---");
        Console.WriteLine(info.Description);
        Console.WriteLine($"Aantal levels: {info.AmountOfLevels}");
        Console.WriteLine($"Start health: {info.StartHealth}");
    }
    catch (HttpRequestException)
    {
        Console.WriteLine("Kan de API niet bereiken. Staat de API aan?");
    }
}

// Start een nieuw spel: naam vragen en welkom heten
static void NieuwSpel()
{
    string naam = VraagNaam();
    Console.WriteLine($"Welkom in de dungeon, {naam}! Je avontuur begint...");
}

// Blijft om een naam vragen tot de speler iets invult
static string VraagNaam()
{
    string? naam = null;

    while (string.IsNullOrWhiteSpace(naam))
    {
        Console.Write("Wat is je naam? ");
        naam = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(naam))
        {
            Console.WriteLine("Je naam mag niet leeg zijn.");
        }
    }

    // Spaties aan begin en eind weghalen
    return naam.Trim();
}