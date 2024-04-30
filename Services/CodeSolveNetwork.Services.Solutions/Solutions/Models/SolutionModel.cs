using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CodeSolveNetwork.Context.Context;
using CodeSolveNetwork.Context.Entities;

namespace CodeSolveNetwork.Services.Solutions
{
    public class SolutionModel
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public string TaskTitle { get; set; }

        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime DateSubmitted { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public bool IsPublished { get; set; }
    }
    public class SolutionModelProfile : Profile
    {
        public SolutionModelProfile()
        {
            CreateMap<Solution, SolutionModel>()
                .BeforeMap<SolutionModelActions>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TaskId, opt => opt.Ignore())
                .ForMember(dest => dest.TaskTitle, opt => opt.Ignore())
                ;
        }

        public class SolutionModelActions : IMappingAction<Solution, SolutionModel>
        {
            private readonly IDbContextFactory<MainDbContext> contextFactory;

            public SolutionModelActions(IDbContextFactory<MainDbContext> contextFactory)
            {
                this.contextFactory = contextFactory;
            }

            public void Process(Solution source, SolutionModel destination, ResolutionContext context)
            {
                using var db = contextFactory.CreateDbContext();

                var solution = db.Solutions.Include(x => x.Task).FirstOrDefault(x => x.Id == source.Id);

                destination.Id = solution.Uid;
                destination.TaskId = solution.Task.Uid;
                destination.TaskTitle = solution.Task.Title;
            }
        }
    }
}
