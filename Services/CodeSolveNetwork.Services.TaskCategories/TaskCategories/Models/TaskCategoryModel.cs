using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CodeSolveNetwork.Context.Context;
using CodeSolveNetwork.Context.Entities;

namespace CodeSolveNetwork.Services.TaskCategories
{
    public class TaskCategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Tasks { get; set; }
    }

    public class TaskCategoryModelProfile : Profile
    {
        public TaskCategoryModelProfile()
        {
            CreateMap<TaskCategory, TaskCategoryModel>()
                .BeforeMap<TaskCategoryModelActions>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Tasks, opt => opt.Ignore())
                ;
        }

        public class TaskCategoryModelActions : IMappingAction<TaskCategory, TaskCategoryModel>
        {
            private readonly IDbContextFactory<MainDbContext> contextFactory;

            public TaskCategoryModelActions(IDbContextFactory<MainDbContext> contextFactory)
            {
                this.contextFactory = contextFactory;
            }

            public void Process(TaskCategory source, TaskCategoryModel destination, ResolutionContext context)
            {
                using var db = contextFactory.CreateDbContext();

                var taskCategory = db.TaskCategories.Include(x => x.Tasks).FirstOrDefault(x => x.Id == source.Id);

                destination.Id = taskCategory.Uid;
                destination.Tasks = taskCategory.Tasks?.Select(x => x.Title);
            }
        }
    }
}
