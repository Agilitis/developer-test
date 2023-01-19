using Microsoft.Extensions.DependencyInjection;
using Taxually.Ports.Inbound.Vat.Interfaces;


namespace Taxually.Core;

public static class CoreServiceRegistration
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddTransient<IVatRegistration, VatRegistration.VatRegistration>();
        return services;
    }
}