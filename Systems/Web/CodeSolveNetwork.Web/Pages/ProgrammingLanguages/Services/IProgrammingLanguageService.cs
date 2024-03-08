using CodeSolveNetwork.Web.Pages.ProgrammingLanguages.Models;

namespace CodeSolveNetwork.Web.Pages.ProgrammingLanguages.Services
{
    public interface IProgrammingLanguageService
    {
        Task<IEnumerable<ProgrammingLanguageModel>> GetProgrammingLanguages();
        Task<ProgrammingLanguageModel> GetProgrammingLanguage(Guid programmingLanguageid);
        Task AddProgrammingLanguage(CreateProgrammingLanguageModel model);
        Task EditProgrammingLanguage(Guid programmingLanguageid, UpdateProgrammingLanguageModel model);
        Task DeleteProgrammingLanguage(Guid programmingLanguageid);
    }
}
