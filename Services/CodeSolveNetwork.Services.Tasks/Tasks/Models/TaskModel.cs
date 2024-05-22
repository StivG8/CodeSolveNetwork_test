using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CodeSolveNetwork.Context.Context;
using CodeSolveNetwork.Context.Entities;
using Task = CodeSolveNetwork.Context.Entities.Task;

namespace CodeSolveNetwork.Services.Tasks
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public Guid ProgrammingLanguageId { get; set; }
        public string ProgrammingLanguage { get; set; }

        public Guid CategoryId { get; set; }
        public string Category { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public IEnumerable<string> Solutions { get; set; }
    }

    public class TaskModelProfile : Profile
    {
        public TaskModelProfile()
        {
            CreateMap<Task, TaskModel>()
                .BeforeMap<TaskModelActions>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ProgrammingLanguageId, opt => opt.Ignore())
                .ForMember(dest => dest.ProgrammingLanguage, opt => opt.Ignore())
                .ForMember(dest => dest.CategoryId, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.Solutions, opt => opt.Ignore())
                ;
        }

        public class TaskModelActions : IMappingAction<Task, TaskModel>
        {
            private readonly IDbContextFactory<MainDbContext> contextFactory;

            public TaskModelActions(IDbContextFactory<MainDbContext> contextFactory)
            {
                this.contextFactory = contextFactory;
            }

            public void Process(Task source, TaskModel destination, ResolutionContext context)
            {
                using var db = contextFactory.CreateDbContext();

                var task = db.Tasks.Include(x => x.Solutions).FirstOrDefault(x => x.Id == source.Id);

                destination.Id = task.Uid;
                destination.ProgrammingLanguageId = task.Language.Uid;
                destination.ProgrammingLanguage = task.Language.Name;
                destination.CategoryId = task.Category.Uid;
                destination.Category = task.Category.Name;
                destination.Solutions = task.Solutions?.Select(x => x.Code);
            }
        }
    }
}
