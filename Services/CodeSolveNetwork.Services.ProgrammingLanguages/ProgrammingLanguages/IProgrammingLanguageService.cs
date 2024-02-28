
using CodeSolveNetwork.Services.ProgrammingLanguages.ProgrammingLanguages.Models;

namespace CodeSolveNetwork.Services.ProgrammingLanguages.ProgrammingLanguages
{
    public interface IProgrammingLanguageService
    {
        Task<IEnumerable<ProgrammingLanguageModel>> GetAll();
        Task<ProgrammingLanguageModel> GetById(Guid id);
        Task<ProgrammingLanguageModel> Create(CreateProgrammingLanguageModel model);
        Task Update(Guid id, UpdateProgrammingLanguageModel model);
        Task Delete(Guid id);
    }
}
