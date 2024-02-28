
using CodeSolveNetwork.Services.ProgrammingLanguages.ProgrammingLanguages;
using Microsoft.Extensions.DependencyInjection;

namespace CodeSolveNetwork.Services.ProgrammingLanguages
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddProgrammingLanguageService(this IServiceCollection services)
        {
            return services
                .AddSingleton<IProgrammingLanguageService, ProgrammingLanguageService>();
        }
    }
}
