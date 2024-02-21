using CodeSolveNetwork.Context.Context;
using CodeSolveNetwork.Context.Factories;
using CodeSolveNetwork.Context.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeSolveNetwork.Context
{
    public static class Bootstrapper
    {
        /// <summary>
        /// Register db context
        /// </summary>
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration = null)
        {
            var settings = Common.Settings.Settings.Load<DbSettings>("Database", configuration);
            services.AddSingleton(settings);

            var dbInitOptionsDelegate = DbContextOptionsFactory.Configure(settings.ConnectionString, settings.Type, true);

            services.AddDbContextFactory<MainDbContext>(dbInitOptionsDelegate);

            return services;
        }
    }
}
