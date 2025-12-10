using DesafioTotvs.Domain.Interfaces.Repositories;
using DesafioTotvs.Infra.Contexts;
using DesafioTotvs.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioTotvs.Infra.Extensions
{
    public static class InfraDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // InMemory database
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("ProductsDb");
            });

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
