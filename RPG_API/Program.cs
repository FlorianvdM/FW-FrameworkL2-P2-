using Game.Api.Services;

namespace Game.Features;

public static class Program
{
    // Startpunt van de API
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Eerst alle onderdelen (services) registreren
        ConfigureServices(builder);

        var app = builder.Build();

        // Daarna de request-pipeline instellen
        Configure(app);

        // API gaat luisteren naar requests
        app.Run();
    }

    // Hier stel je in wat er met een binnenkomend request gebeurt
    private static void Configure(WebApplication app)
    {
        // Koppelt de routes uit de controllers (bijv. /api/game/status)
        app.MapControllers();
    }

    // Hier registreer je onderdelen die de API nodig heeft
    private static void ConfigureServices(WebApplicationBuilder builder)
    {
        // Zorgt dat controllers werken
        builder.Services.AddControllers();

        // GameService registreren: per HTTP-request wordt er één nieuwe gemaakt
        builder.Services.AddScoped<GameService>();
    }
}