
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeSolveNetwork.Api.Settings
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddApiSpecialSettings(this IServiceCollection services, IConfiguration configuration = null)
        {
            var settings = Common.Settings.Settings.Load<ApiSpecialSettings>("ApiSpecial", configuration);
            services.AddSingleton(settings);

            return services;
        }
    }
}
