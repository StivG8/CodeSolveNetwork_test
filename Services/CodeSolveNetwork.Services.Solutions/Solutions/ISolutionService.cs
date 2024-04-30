
namespace CodeSolveNetwork.Services.Solutions
{
    public interface ISolutionService
    {
        Task<IEnumerable<SolutionModel>> GetAll();
        Task<SolutionModel> GetById(Guid id);
        Task<SolutionModel> Create(CreateSolutionModel model);
        Task Update(Guid id, UpdateSolutionModel model);
        Task Delete(Guid id);
    }
}