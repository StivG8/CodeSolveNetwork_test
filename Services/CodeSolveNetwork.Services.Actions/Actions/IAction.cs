using System.Threading.Tasks;

namespace CodeSolveNetwork.Services.Actions
{
    public interface IAction
    {
        Task PublicateProgrammingLanguage(PublicateProgrammingLanguageModel model);
    }
}
