using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trion.Domain.CoachAggregate;
using Trion.Infrastructure.Persistence;
using Trion.Infrastructure.Persistence.Repositories;

namespace Trion.Infrastructure;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddInfrastructure(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
        
            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Trion connection string not configured");
        
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.RegisterRepositories();
        
            return services;
        }

        private IServiceCollection RegisterRepositories()
        {
            services.AddScoped<ICoachRepository, CoachRepository>();
        
            return services;
        }
    }
}