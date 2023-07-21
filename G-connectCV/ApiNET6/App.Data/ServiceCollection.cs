using Microsoft.Extensions.DependencyInjection;

namespace App.Data
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddAppDataLibrary(this IServiceCollection services)
        {

            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
