using CodeSolveNetwork.Web.Pages.Solutions.Models;
using System.Net.Http.Json;

namespace CodeSolveNetwork.Web.Pages.Solutions.Services
{
    public class SolutionService(HttpClient httpClient) : ISolutionService
    {
        public async Task<IEnumerable<SolutionModel>> GetSolutions()
        {
            var response = await httpClient.GetAsync("v1/solution");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }

            return await response.Content.ReadFromJsonAsync<IEnumerable<SolutionModel>>() ?? new List<SolutionModel>();
        }

        public async Task<SolutionModel> GetSolution(Guid solutoinid)
        {
            var response = await httpClient.GetAsync($"v1/solution/{solutoinid}");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }

            return await response.Content.ReadFromJsonAsync<SolutionModel>() ?? new();
        }

        public async Task AddSolution(CreateSolutionModel model)
        {
            var requestContent = JsonContent.Create(model);
            var response = await httpClient.PostAsync("v1/solution", requestContent);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }
        public async Task EditSolution(Guid solutoinid, UpdateSolutionModel model)
        {
            var requestContent = JsonContent.Create(model);
            var response = await httpClient.PutAsync($"v1/solution/{solutoinid}", requestContent);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }

        public async Task DeleteSolution(Guid solutoinid)
        {
            var response = await httpClient.DeleteAsync($"v1/solution/{solutoinid}");

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }
    }
}
