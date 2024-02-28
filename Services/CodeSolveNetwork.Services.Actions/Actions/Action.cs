using CodeSolveNetwork.Services.RabbitMq;
using System.Threading.Tasks;

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
    }
}
