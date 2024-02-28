using CodeSolveNetwork.Common.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeSolveNetwork.Services.RabbitMq
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration = null)
        {
            var settings = Settings.Load<RabbitMqSettings>("RabbitMq", configuration);
            services.AddSingleton(settings);

            services.AddSingleton<IRabbitMq, RabbitMq>();

            return services;
        }
    }
}
