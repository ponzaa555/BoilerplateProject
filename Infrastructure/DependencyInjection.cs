using Microsoft.Extensions.DependencyInjection;

namespace InfraStructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services)
        {
            return services;   
        }

        public static IServiceCollection AddRepository (this IServiceCollection services)
        {
            
            return services;
        }
    }
}