
using Application.Common.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;


public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        // services.AddDbContext<ApplicationDbContext>(options =>
        //     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        //         builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        // services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        // services.AddHttpContextAccessor();

        services.AddTransient<IDateTime, DateTimeService>();
        // services.AddTransient<IManagerHttpService, ManagerHttpService>();
        // services.AddTransient<ICustomerHttpService, CustomerHttpService>();

        //AzureBlob
        // services.Configure<AzureBlobSettings>(configuration.GetSection("AzureBlobSettings"));
        // services.AddTransient<IBlobStorageService, BlobStorageService>();

        // // services.AddSingleton<IFileUploadService, FileUploadService>();
        // services.AddSingleton<IFileUploadService, FileUploadServiceBlob>();
        // services.AddTransient(typeof(IHttpGlobalService<>), typeof(HttpGlobalService<>));

        return services;
    }
}
