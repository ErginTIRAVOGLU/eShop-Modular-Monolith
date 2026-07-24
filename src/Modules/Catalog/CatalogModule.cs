
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Behaviors;
using Shared.Data.Interceptors;


namespace Catalog;


public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        //services.AddScoped<ICatalogService, CatalogService>();
        //services.AddScoped<ICatalogRepository, CatalogRepository>();

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        var connectionString = configuration.GetConnectionString("Database");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<CatalogDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IDataSeeder, CatalogDataSeeder>();

        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
    {
        //app.UseApplicationServices();
        //app.UseInfrastructureServices();
        //app.UseApiServices();

        app.UseMigration<CatalogDbContext>();
        //InitialiseDatabaseAsync(app).GetAwaiter().GetResult();

        return app;
    }

    /*  private static async Task InitialiseDatabaseAsync(IApplicationBuilder app)
     {
         using var scope = app.ApplicationServices.CreateAsyncScope();

         var context = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();
         await context.Database.MigrateAsync();
     } */
}
