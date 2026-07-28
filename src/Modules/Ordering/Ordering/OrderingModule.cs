using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering;

public static class OrderingModule
{
    public static IServiceCollection AddOrderingModule(this IServiceCollection services, 
        IConfiguration configuration)
    {
        //services.AddScoped<IOrderingService, OrderingService>();
        //services.AddScoped<IOrderingRepository, OrderingRepository>();
        
        //services
        //    .AddApplicationServices()
        //    .AddInfrastructureServices(configuration)
        //    .AddApiServices(configuration);

        return services;
    }

    public static IApplicationBuilder UseOrderingModule(this IApplicationBuilder app)
    {
        //app.UseApplicationServices();
        //app.UseInfrastructureServices();
        //app.UseApiServices();

        return app;
    }
}
