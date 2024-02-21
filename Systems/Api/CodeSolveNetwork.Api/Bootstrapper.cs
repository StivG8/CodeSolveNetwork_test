using CodeSolveNetwork.Api.Settings;
using CodeSolveNetwork.Context.Seeder;
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
                .AddLogSettings()
                .AddSwaggerSettings()
                .AddAppLogger()
                .AddDbSeeder()
                .AddApiSpecialSettings();

            return service;
        }
    }

}
