using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;
using WorldLeague.Application.Behaviours;

namespace WorldLeague.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });

        return services;

    }
}
