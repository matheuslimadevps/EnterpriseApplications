using EAS.Catalogo.API.Data;
using EAS.Catalogo.API.Data.Repository;
using EAS.Catalogo.API.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EAS.Catalogo.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<CatalogoContext>();
        }
    }
}
