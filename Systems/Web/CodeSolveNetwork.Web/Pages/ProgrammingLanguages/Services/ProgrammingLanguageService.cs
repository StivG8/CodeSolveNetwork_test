using CodeSolveNetwork.Web.Pages.ProgrammingLanguages.Models;
using System.Net;
using System.Net.Http.Json;

namespace CodeSolveNetwork.Web.Pages.ProgrammingLanguages.Services
{
    public class ProgrammingLanguageService(HttpClient httpClient) : IProgrammingLanguageService
    {
        public async Task<IEnumerable<ProgrammingLanguageModel>> GetProgrammingLanguages()
        {
            var response = await httpClient.GetAsync("v1/programmingLanguage");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }

            return await response.Content.ReadFromJsonAsync<IEnumerable<ProgrammingLanguageModel>>() ?? new List<ProgrammingLanguageModel>();
        }

        public async Task<ProgrammingLanguageModel> GetProgrammingLanguage(Guid programmingLanguageid)
        {
            var response = await httpClient.GetAsync($"v1/programmingLanguage/{programmingLanguageid}");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }

            return await response.Content.ReadFromJsonAsync<ProgrammingLanguageModel>() ?? new();
        }

        public async Task AddProgrammingLanguage(CreateProgrammingLanguageModel model)
        {
            var requestContent = JsonContent.Create(model);
            var response = await httpClient.PostAsync("v1/programmingLanguage", requestContent);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }

        public async Task EditProgrammingLanguage(Guid programmingLanguageid, UpdateProgrammingLanguageModel model)
        {
            var requestContent = JsonContent.Create(model);
            var response = await httpClient.PutAsync($"v1/programmingLanguage/{programmingLanguageid}", requestContent);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }

        public async Task DeleteProgrammingLanguage(Guid programmingLanguageid)
        {
            var response = await httpClient.DeleteAsync($"v1/programmingLanguage/{programmingLanguageid}");

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }
    }
}
