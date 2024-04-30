
using Microsoft.Extensions.DependencyInjection;

namespace CodeSolveNetwork.Services.Tasks
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddTaskService(this IServiceCollection services)
        {
            return services
                .AddSingleton<ITaskService, TaskService>();
        }
    }
}
