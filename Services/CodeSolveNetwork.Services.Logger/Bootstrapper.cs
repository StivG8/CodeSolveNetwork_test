using CodeSolveNetwork.Services.Logger.Logger;
using Microsoft.Extensions.DependencyInjection;

namespace CodeSolveNetwork.Services.Logger
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddAppLogger(this IServiceCollection services)
        {
            return services
                .AddSingleton<IAppLogger, AppLogger>();
        }
    }
}
