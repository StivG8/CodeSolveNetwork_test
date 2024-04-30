using CodeSolveNetwork.Web.Pages.TaskCategories.Models;

namespace CodeSolveNetwork.Web.Pages.TaskCategories.Services
{
    public interface ITaskCategoryService
    {
        Task<IEnumerable<TaskCategoryModel>> GetTaskCategories();
        Task<TaskCategoryModel> GetTaskCategory(Guid taskCategoryid);
        Task AddTaskCategory(CreateTaskCategoryModel model);
        Task EditTaskCategory(Guid taskCategoryid, UpdateTaskCategoryModel model);
        Task DeleteTaskCategory(Guid taskCategoryid);
    }
}
