using AutoMapper;
using CodeSolveNetwork.Common.Exceptions;
using CodeSolveNetwork.Common.Validator;
using CodeSolveNetwork.Context.Context;
using CodeSolveNetwork.Context.Entities;
using CodeSolveNetwork.Services.Actions;
using Microsoft.EntityFrameworkCore;
using Task = CodeSolveNetwork.Context.Entities.Task;

namespace CodeSolveNetwork.Services.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly IDbContextFactory<MainDbContext> dbContextFactory;
        private readonly IMapper mapper;
        private readonly IAction action;
        private readonly IModelValidator<CreateTaskModel> createTaskModelValidator;
        private readonly IModelValidator<UpdateTaskModel> updateTaskModelValidator;

        public TaskService(
            IDbContextFactory<MainDbContext> dbContextFactory,
            IMapper mapper,
            IAction action,
            IModelValidator<CreateTaskModel> createTaskModelValidator,
            IModelValidator<UpdateTaskModel> updateTaskModelValidator
            )
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
            this.action = action;
            this.createTaskModelValidator = createTaskModelValidator;
            this.updateTaskModelValidator = updateTaskModelValidator;
        }

        public async Task<IEnumerable<TaskModel>> GetAll()
        {
            using var context = await dbContextFactory.CreateDbContextAsync();

            var tasks = await context.Tasks
                .Include(x => x.Language)
                .Include(x => x.Category)
                .Include(x => x.Solutions)
                .ToListAsync();

            var result = mapper.Map<IEnumerable<TaskModel>>(tasks);

            return result;
        }

        public async Task<TaskModel> GetById(Guid id)
        {
            using var context = await dbContextFactory.CreateDbContextAsync();

            var task = await context.Tasks
                .Include(x => x.Language)
                .Include(x => x.Category)
                .Include(x => x.Solutions)
                .FirstOrDefaultAsync(x => x.Uid == id);

            var result = mapper.Map<TaskModel>(task);

            return result;
        }

        public async Task<TaskModel> Create(CreateTaskModel model)
        {
            await createTaskModelValidator.CheckAsync(model);

            using var context = await dbContextFactory.CreateDbContextAsync();

            var task = mapper.Map<Task>(model);

            await context.Tasks.AddAsync(task);

            await context.SaveChangesAsync();

            await action.PublicateTask(new PublicateTaskModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description
            });

            return mapper.Map<TaskModel>(task);
        }

        public async System.Threading.Tasks.Task Update(Guid id, UpdateTaskModel model)
        {
            await updateTaskModelValidator.CheckAsync(model);

            using var context = await dbContextFactory.CreateDbContextAsync();

            var task = await context.Tasks.Where(x => x.Uid == id).FirstOrDefaultAsync();

            task = mapper.Map(model, task);

            context.Tasks.Update(task);

            await context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Delete(Guid id)
        {
            using var context = await dbContextFactory.CreateDbContextAsync();

            var task = await context.Tasks.Where(x => x.Uid == id).FirstOrDefaultAsync();

            if (task == null)
                throw new ProcessException($"Task (ID = {id}) not found.");

            context.Tasks.Remove(task);

            await context.SaveChangesAsync();
        }
    }
}
