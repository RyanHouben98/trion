using Microsoft.Extensions.DependencyInjection;

namespace Trion.Application;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddApplication()
        {
            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            
            return services;
        }   
    }
}