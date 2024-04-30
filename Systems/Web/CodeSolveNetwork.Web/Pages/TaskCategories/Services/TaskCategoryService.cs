using CodeSolveNetwork.Web.Pages.TaskCategories.Models;
using System.Net.Http.Json;

namespace CodeSolveNetwork.Web.Pages.TaskCategories.Services
{
    public class TaskCategoryService(HttpClient httpClient) : ITaskCategoryService
    {
        public async Task<IEnumerable<TaskCategoryModel>> GetTaskCategories()
        {
            var response = await httpClient.GetAsync("v1/taskCategory");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }

            return await response.Content.ReadFromJsonAsync<IEnumerable<TaskCategoryModel>>() ?? new List<TaskCategoryModel>();
        }

        public async Task<TaskCategoryModel> GetTaskCategory(Guid taskCategoryid)
        {
            var response = await httpClient.GetAsync($"v1/taskCategory/{taskCategoryid}");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }

            return await response.Content.ReadFromJsonAsync<TaskCategoryModel>() ?? new();
        }
        public async Task AddTaskCategory(CreateTaskCategoryModel model)
        {
            var requestContent = JsonContent.Create(model);
            var response = await httpClient.PostAsync("v1/taskCategory", requestContent);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }
        public async Task EditTaskCategory(Guid taskCategoryid, UpdateTaskCategoryModel model)
        {
            var requestContent = JsonContent.Create(model);
            var response = await httpClient.PutAsync($"v1/taskCategory/{taskCategoryid}", requestContent);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }
        public async Task DeleteTaskCategory(Guid taskCategoryid)
        {
            var response = await httpClient.DeleteAsync($"v1/taskCategory/{taskCategoryid}");

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }
    }
}
