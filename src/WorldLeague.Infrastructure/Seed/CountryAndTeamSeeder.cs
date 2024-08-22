using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorldLeague.Domain.Entities;
using WorldLeague.Infrastructure.Persistence;

namespace WorldLeague.Infrastructure.Seed;

internal class CountryAndTeamSeeder : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public CountryAndTeamSeeder(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {

        using var scope = _serviceProvider.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<WorldLeagueDbContext>();

        if (context.Countries.Any())
        {
            return;
        }

        await context.Countries.AddRangeAsync(CreateCountries());

        await context.SaveChangesAsync();

    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private List<Country> CreateCountries()
    {

        var country1 = new Country("Türkiye");

        country1.AddTeam("Adesso İstanbul");

        country1.AddTeam("Adesso Ankara");

        country1.AddTeam("Adesso İzmir");

        country1.AddTeam("Adesso Antalya");

        var country2 = new Country("Almanya");

        country2.AddTeam("Adesso Berlin");

        country2.AddTeam("Adesso Münih");

        country2.AddTeam("Adesso Frankfurt");

        country2.AddTeam("Adesso Dortmund");

        var country3 = new Country("İtalya");

        country3.AddTeam("Adesso Roma");

        country3.AddTeam("Adesso Milano");

        country3.AddTeam("Adesso Porto");

        country3.AddTeam("Adesso Venedik");

        var country4 = new Country("İspanya");

        country4.AddTeam("Adesso Madrid");

        country4.AddTeam("Adesso Barselona");

        country4.AddTeam("Adesso Sevilla");

        country4.AddTeam("Adesso Granada");

        var country5 = new Country("Fransa");

        country5.AddTeam("Adesso Paris");

        country5.AddTeam("Adesso Marsilya");

        country5.AddTeam("Adesso Nice");

        country5.AddTeam("Adesso Lyon");

        var country6 = new Country("Hollanda");

        country6.AddTeam("Adesso Amsterdam");

        country6.AddTeam("Adesso Rotterdam");

        country6.AddTeam("Adesso Lahey");

        country6.AddTeam("Adesso Eindhoven");


        var country7 = new Country("Portekiz");

        country7.AddTeam("Adesso Lizbon");

        country7.AddTeam("Adesso Porto");

        country7.AddTeam("Adesso Braga");

        country7.AddTeam("Adesso Coimbra");

        var country8 = new Country("Belçika");

        country8.AddTeam("Adesso Brüksel");

        country8.AddTeam("Adesso Brugge");

        country8.AddTeam("Adesso Gent");

        country8.AddTeam("Adesso Anvers");


        return [country1, country2, country3, country4, country5, country6, country7, country8];
    }
}
