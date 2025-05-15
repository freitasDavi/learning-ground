

using Microsoft.Extensions.DependencyInjection;
using Unit.Core.Interfaces.Products;
using Unit.Core.Services;

namespace Unit.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}