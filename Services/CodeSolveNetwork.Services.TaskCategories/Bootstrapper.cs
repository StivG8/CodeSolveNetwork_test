
using Microsoft.Extensions.DependencyInjection;

namespace CodeSolveNetwork.Services.TaskCategories
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddTaskCategoryService(this IServiceCollection services)
        {
            return services
                .AddSingleton<ITaskCategoryService, TaskCategoryService>();
        }
    }
}
