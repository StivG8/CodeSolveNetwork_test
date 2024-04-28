namespace CodeSolveNetwork.Services.Tasks
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskModel>> GetAll();
        Task<TaskModel> GetById(Guid id);
        Task<TaskModel> Create(CreateTaskModel model);
        Task Update(Guid id, UpdateTaskModel model);
        Task Delete(Guid id);
    }
}