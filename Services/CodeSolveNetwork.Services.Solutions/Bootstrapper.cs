
using Microsoft.Extensions.DependencyInjection;

namespace CodeSolveNetwork.Services.Solutions
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddSolutionService(this IServiceCollection services)
        {
            return services
                .AddSingleton<ISolutionService, SolutionService>();
        }
    }
}
