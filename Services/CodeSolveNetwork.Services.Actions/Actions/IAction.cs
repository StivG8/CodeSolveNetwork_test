
namespace CodeSolveNetwork.Services.Actions
{
    public interface IAction
    {
        Task PublicateProgrammingLanguage(PublicateProgrammingLanguageModel model);
        Task PublicateTask(PublicateTaskModel model);
    }
}
