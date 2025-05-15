
using Microsoft.Extensions.DependencyInjection;
using Unit.Core.Interfaces.Products;
using Unit.Infra.Repositories;

namespace Unit.Infra
{
    public static class InfraDependencyInjectionHandler
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}