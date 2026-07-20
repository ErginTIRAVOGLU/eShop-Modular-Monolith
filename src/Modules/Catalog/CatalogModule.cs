using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog;


public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services, 
        IConfiguration configuration)
    {
        //services.AddScoped<ICatalogService, CatalogService>();
        //services.AddScoped<ICatalogRepository, CatalogRepository>();
        
        //services
        //    .AddApplicationServices()
        //    .AddInfrastructureServices(configuration)
        //    .AddApiServices(configuration);

        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
    {
        //app.UseApplicationServices();
        //app.UseInfrastructureServices();
        //app.UseApiServices();

        return app;
    }

}
