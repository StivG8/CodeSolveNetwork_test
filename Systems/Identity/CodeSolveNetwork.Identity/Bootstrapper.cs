using CodeSolveNetwork.Services.Settings;

namespace CodeSolveNetwork.Identity
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services
                .AddMainSettings()
                .AddLogSettings()
                ;

            return services;
        }
    }
}
