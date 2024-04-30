using CodeSolveNetwork.Web.Pages.Tasks.Models;

namespace CodeSolveNetwork.Web.Pages.Tasks.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskModel>> GetTasks();
        Task<TaskModel> GetTask(Guid taskid);
        Task AddTask(CreateTaskModel model);
        Task EditTask(Guid taskid, UpdateTaskModel model);
        Task DeleteTask(Guid taskid);
    }
}
