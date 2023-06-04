using Application.Common.Interfaces;
using Infrastructure.Persistence.Configurations.Context;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, string wwwrootPath)
        {
            var connectionString = configuration.GetConnectionString("MariaDB")!;

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<IEmailService>(new EmailManager(wwwrootPath));

            return services;
        }
    }
}