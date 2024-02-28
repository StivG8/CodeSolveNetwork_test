using CodeSolveNetwork.Services.Logger;
using CodeSolveNetwork.Services.RabbitMq;

namespace CodeSolveNetwork.Worker
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services
                .AddAppLogger()
                .AddRabbitMq()
                ;

            services.AddSingleton<ITaskExecutor, TaskExecutor>();

            return services;
        }
    }
}
