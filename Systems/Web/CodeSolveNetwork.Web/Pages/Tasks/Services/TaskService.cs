using CodeSolveNetwork.Web.Pages.Tasks.Models;
using System.Net.Http.Json;

namespace CodeSolveNetwork.Web.Pages.Tasks.Services
{
    public class TaskService(HttpClient httpClient) : ITaskService
    {
        public async Task<IEnumerable<TaskModel>> GetTasks()
        {
            var response = await httpClient.GetAsync("v1/task");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }

            return await response.Content.ReadFromJsonAsync<IEnumerable<TaskModel>>() ?? new List<TaskModel>();
        }

        public async Task<TaskModel> GetTask(Guid taskid)
        {
            var response = await httpClient.GetAsync($"v1/task/{taskid}");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }

            return await response.Content.ReadFromJsonAsync<TaskModel>() ?? new();
        }

        public async Task AddTask(CreateTaskModel model)
        {
            var requestContent = JsonContent.Create(model);
            var response = await httpClient.PostAsync("v1/task", requestContent);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }
        public async Task EditTask(Guid taskid, UpdateTaskModel model)
        {
            var requestContent = JsonContent.Create(model);
            var response = await httpClient.PutAsync($"v1/task/{taskid}", requestContent);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }

        public async Task DeleteTask(Guid taskid)
        {
            var response = await httpClient.DeleteAsync($"v1/task/{taskid}");

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }
    }
}
