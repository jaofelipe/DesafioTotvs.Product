using DesafioTotvs.Application.Interfaces;
using DesafioTotvs.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioTotvs.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductAppService, ProductAppService>();
            return services;
        }
    }
}
