using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PRN231_Group12.Assignment2.Repo.Interfaces;
using PRN231_Group12.Assignment2.Repo.Repository;
using PRN231_Group12.Assignment2.Repo.Shared;

namespace PRN231_Group12.Assignment2.Repo;

public static class ConfigureServices
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddScoped<BookPublishingDBContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
    
            return services;
        }
    
    private static IServiceCollection AddDbContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionStrings = configuration.GetSection(nameof(ConnectionStrings)).Get<ConnectionStrings>();

        services.AddDbContext<BookPublishingDBContext>(builder =>
        {
            builder.UseSqlServer(connectionStrings.BookPublishingDB!, options =>
            {
                options.MigrationsAssembly(typeof(BookPublishingDBContext).Assembly.FullName);
            });
        });

        return services;
    }
}