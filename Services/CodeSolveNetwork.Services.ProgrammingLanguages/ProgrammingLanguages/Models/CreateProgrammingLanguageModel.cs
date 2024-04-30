using AutoMapper;
using CodeSolveNetwork.Common.ValidationRules;
using CodeSolveNetwork.Context.Context;
using CodeSolveNetwork.Context.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CodeSolveNetwork.Services.ProgrammingLanguages.ProgrammingLanguages.Models
{
    public class CreateProgrammingLanguageModel
    {
        public string Name { get; set; }
    }
    public class CreateProgrammingLanguageModelProfile : Profile
    {
        public CreateProgrammingLanguageModelProfile()
        {
            CreateMap<CreateProgrammingLanguageModel, ProgrammingLanguage>()
                .AfterMap<CreateProgrammingLanguageModelActions>();
        }

        public class CreateProgrammingLanguageModelActions : IMappingAction<CreateProgrammingLanguageModel, ProgrammingLanguage>
        {
            private readonly IDbContextFactory<MainDbContext> contextFactory;

            public CreateProgrammingLanguageModelActions(IDbContextFactory<MainDbContext> contextFactory)
            {
                this.contextFactory = contextFactory;
            }

            public void Process(CreateProgrammingLanguageModel source, ProgrammingLanguage destination, ResolutionContext context)
            {
                using var db = contextFactory.CreateDbContext();
            }
        }
    }
    public class CreateProgrammingLanguageModelValidator : AbstractValidator<CreateProgrammingLanguageModel>
    {
        public CreateProgrammingLanguageModelValidator(IDbContextFactory<MainDbContext> contextFactory)
        {
            RuleFor(x => x.Name).ProgrammingLanguageName();
        }
    }
}
