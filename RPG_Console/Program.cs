// Hoofdmenu van de dungeon crawler
// De lus blijft draaien tot de speler kiest om af te sluiten
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
            Console.WriteLine("Tot ziens!");
            doorgaan = false;
            break;
        default:
            // Alles wat geen 1 of 2 is, is een onbekende keuze
            Console.WriteLine("Onbekende keuze, kies 1 of 2.");
            break;
    }
}

// Laat het menu zien
static void ToonMenu()
{
    Console.WriteLine();
    Console.WriteLine("=== DUNGEON CRAWLER ===");
    Console.WriteLine("1. Nieuw spel");
    Console.WriteLine("2. Afsluiten");
    Console.Write("Maak een keuze: ");
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