using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CodeSolveNetwork.Context.Context;
using CodeSolveNetwork.Context.Entities;

namespace CodeSolveNetwork.Services.ProgrammingLanguages.ProgrammingLanguages.Models
{
    public class ProgrammingLanguageModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<string> Tasks { get; set; }
    }
    public class ProgrammingLanguageModelProfile : Profile
    {
        public ProgrammingLanguageModelProfile()
        {
            CreateMap<ProgrammingLanguage, ProgrammingLanguageModel>()
                .BeforeMap<ProgrammingLanguageModelActions>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Tasks, opt => opt.Ignore())
                ;
        }

        public class ProgrammingLanguageModelActions : IMappingAction<ProgrammingLanguage, ProgrammingLanguageModel>
        {
            private readonly IDbContextFactory<MainDbContext> contextFactory;

            public ProgrammingLanguageModelActions(IDbContextFactory<MainDbContext> contextFactory)
            {
                this.contextFactory = contextFactory;
            }

            public void Process(ProgrammingLanguage source, ProgrammingLanguageModel destination, ResolutionContext context)
            {
                using var db = contextFactory.CreateDbContext();

                var programmingLanguage = db.ProgrammingLanguages.Include(x => x.Tasks).FirstOrDefault(x => x.Id == source.Id);

                destination.Id = programmingLanguage.Uid;
                destination.Tasks = programmingLanguage.Tasks?.Select(x => x.Title);
            }
        }
    }
}
