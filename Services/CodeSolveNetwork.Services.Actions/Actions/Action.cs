﻿using CodeSolveNetwork.Services.RabbitMq;

namespace CodeSolveNetwork.Services.Actions
{
    public class Action : IAction
    {
        private readonly IRabbitMq rabbitMq;

        public Action(IRabbitMq rabbitMq)
        {
            this.rabbitMq = rabbitMq;
        }

        public async Task PublicateProgrammingLanguage(PublicateProgrammingLanguageModel model)
        {
            await rabbitMq.PushAsync(QueueNames.PUBLICATE_PROGRAMMINGLANGUAGE, model);
        }
        public async Task PublicateTask(PublicateTaskModel model)
        {
            await rabbitMq.PushAsync(QueueNames.PUBLICATE_TASK, model);
        }
    }
}
