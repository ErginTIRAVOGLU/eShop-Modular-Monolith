using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Basket;

public static class BasketModule
{
    public static IServiceCollection AddBasketModule(this IServiceCollection services, 
        IConfiguration configuration)
    {
        //services.AddScoped<IBasketService, BasketService>();
        //services.AddScoped<IBasketRepository, BasketRepository>();
        
        //services
        //    .AddApplicationServices()
        //    .AddInfrastructureServices(configuration)
        //    .AddApiServices(configuration);

        return services;
    }

    public static IApplicationBuilder UseBasketModule(this IApplicationBuilder app)
    {
        //app.UseApplicationServices();
        //app.UseInfrastructureServices();
        //app.UseApiServices();

        return app;
    }
}
