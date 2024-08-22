using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorldLeague.Application.Abstractions;
using WorldLeague.Domain.Repositories;
using WorldLeague.Infrastructure.Persistence;
using WorldLeague.Infrastructure.Persistence.Repositories;

namespace WorldLeague.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<WorldLeagueDbContext>(options =>
                options.UseInMemoryDatabase("worldleaguedb")
                );

            services.AddScoped<IDrawRepository, DrawRepository>();

            services.AddScoped<ICountryRepository, CountryRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<WorldLeagueDbContext>());

            return services;
        }

    }
}
