using AutoMapper;
using CodeSolveNetwork.Common.Exceptions;
using CodeSolveNetwork.Common.Validator;
using CodeSolveNetwork.Context.Context;
using CodeSolveNetwork.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeSolveNetwork.Services.TaskCategories
{
    public class TaskCategoryService : ITaskCategoryService
    {
        private readonly IDbContextFactory<MainDbContext> dbContextFactory;
        private readonly IMapper mapper;
        private readonly IModelValidator<CreateTaskCategoryModel> createTaskCategoryModelValidator;
        private readonly IModelValidator<UpdateTaskCategoryModel> updateTaskCategoryModelValidator;

        public TaskCategoryService(
            IDbContextFactory<MainDbContext> dbContextFactory,
            IMapper mapper,
            IModelValidator<CreateTaskCategoryModel> createTaskCategoryModelValidator,
            IModelValidator<UpdateTaskCategoryModel> updateTaskCategoryModelValidator
            )
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
            this.createTaskCategoryModelValidator = createTaskCategoryModelValidator;
            this.updateTaskCategoryModelValidator = updateTaskCategoryModelValidator;
        }

        public async Task<IEnumerable<TaskCategoryModel>> GetAll()
        {
            using var context = await dbContextFactory.CreateDbContextAsync();

            var taskCategories = await context.TaskCategories
                .Include(x => x.Tasks)
                .ToListAsync();

            var result = mapper.Map<IEnumerable<TaskCategoryModel>>(taskCategories);

            return result;
        }

        public async Task<TaskCategoryModel> GetById(Guid id)
        {
            using var context = await dbContextFactory.CreateDbContextAsync();

            var taskCategory = await context.TaskCategories
                .Include(x => x.Tasks)
                .FirstOrDefaultAsync(x => x.Uid == id);

            var result = mapper.Map<TaskCategoryModel>(taskCategory);

            return result;
        }

        public async Task<TaskCategoryModel> Create(CreateTaskCategoryModel model)
        {
            await createTaskCategoryModelValidator.CheckAsync(model);

            using var context = await dbContextFactory.CreateDbContextAsync();

            var taskCategory = mapper.Map<TaskCategory>(model);

            await context.TaskCategories.AddAsync(taskCategory);

            await context.SaveChangesAsync();

            return mapper.Map<TaskCategoryModel>(taskCategory);
        }

        public async System.Threading.Tasks.Task Update(Guid id, UpdateTaskCategoryModel model)
        {
            await updateTaskCategoryModelValidator.CheckAsync(model);

            using var context = await dbContextFactory.CreateDbContextAsync();

            var taskCategory = await context.TaskCategories.Where(x => x.Uid == id).FirstOrDefaultAsync();

            taskCategory = mapper.Map(model, taskCategory);

            context.TaskCategories.Update(taskCategory);

            await context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Delete(Guid id)
        {
            using var context = await dbContextFactory.CreateDbContextAsync();

            var taskCategory = await context.TaskCategories.Where(x => x.Uid == id).FirstOrDefaultAsync();

            if (taskCategory == null)
                throw new ProcessException($"Task Category (ID = {id}) not found.");

            context.TaskCategories.Remove(taskCategory);

            await context.SaveChangesAsync();
        }
    }
}
