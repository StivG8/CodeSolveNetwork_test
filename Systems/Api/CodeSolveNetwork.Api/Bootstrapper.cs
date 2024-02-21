using CodeSolveNetwork.Services.Logger;
using CodeSolveNetwork.Services.Settings;

namespace CodeSolveNetwork.Api
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection service, IConfiguration configuration = null)
        {
            service
                .AddMainSettings()
                .AddSwaggerSettings()
                .AddLogSettings()
                .AddAppLogger();

            return service;
        }
    }

}
