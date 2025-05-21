using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationDepedencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register MediaR
            services.AddMediatR(typeof(ApplicationDepedencyInjection).Assembly);
            
            return services;
        }
    }
}