using CodeSolveNetwork.Web.Pages.Solutions.Models;

namespace CodeSolveNetwork.Web.Pages.Solutions.Services
{
    public interface ISolutionService
    {
        Task<IEnumerable<SolutionModel>> GetSolutions();
        Task<SolutionModel> GetSolution(Guid solutoinid);
        Task AddSolution(CreateSolutionModel model);
        Task EditSolution(Guid solutoinid, UpdateSolutionModel model);
        Task DeleteSolution(Guid solutoinid);
    }
}
