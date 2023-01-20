using Microsoft.Extensions.DependencyInjection;
using Taxually.Core.VatRegistration.RegistrationStrategies;
using Taxually.Ports.Inbound.Vat.Interfaces;


namespace Taxually.Core;

public static class CoreServiceRegistration
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddTransient<IRegistrationStrategy, GermanStrategy>();
        services.AddTransient<IRegistrationStrategy, FrenchStrategy>();
        services.AddTransient<IRegistrationStrategy, EnglishStrategy>();
        services.AddTransient<IVatRegistration, VatRegistration.VatRegistration>();
        return services;
    }
}