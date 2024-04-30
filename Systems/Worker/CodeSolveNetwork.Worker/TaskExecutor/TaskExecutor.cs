using CodeSolveNetwork.Services.Actions;
using CodeSolveNetwork.Services.Logger.Logger;
using CodeSolveNetwork.Services.RabbitMq;

namespace CodeSolveNetwork.Worker
{
    public class TaskExecutor : ITaskExecutor
    {
        private readonly IAppLogger logger;
        private readonly IRabbitMq rabbitMq;

        public TaskExecutor(
            IAppLogger logger,
            IRabbitMq rabbitMq
        )
        {
            this.logger = logger;
            this.rabbitMq = rabbitMq;
        }

        public void Start()
        {
            rabbitMq.Subscribe<PublicateProgrammingLanguageModel>(QueueNames.PUBLICATE_PROGRAMMINGLANGUAGE, async data =>
            {
                logger.Information($"Starting publication of the book::: {data.Id}");

                await Task.Delay(3000);

                logger.Information($"The book was publicated::: {data.Id} | {data.Name}");
            });

            rabbitMq.Subscribe<PublicateTaskModel>(QueueNames.PUBLICATE_TASK, async data =>
            {
                logger.Information($"Starting publication of the book::: {data.Id}");

                await Task.Delay(3000);

                logger.Information($"The book was publicated::: {data.Id} | {data.Title} | {data.Description}");
            });
        }

    }
}
