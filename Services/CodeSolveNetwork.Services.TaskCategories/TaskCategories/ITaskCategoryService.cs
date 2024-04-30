
namespace CodeSolveNetwork.Services.TaskCategories
{
    public interface ITaskCategoryService
    {
        Task<IEnumerable<TaskCategoryModel>> GetAll();
        Task<TaskCategoryModel> GetById(Guid id);
        Task<TaskCategoryModel> Create(CreateTaskCategoryModel model);
        Task Update(Guid id, UpdateTaskCategoryModel model);
        Task Delete(Guid id);
    }
}
