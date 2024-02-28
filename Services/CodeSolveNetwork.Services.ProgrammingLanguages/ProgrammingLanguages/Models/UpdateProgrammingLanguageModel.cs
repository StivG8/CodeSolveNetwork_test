
using AutoMapper;
using CodeSolveNetwork.Common.ValidationRules;
using CodeSolveNetwork.Context.Context;
using CodeSolveNetwork.Context.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CodeSolveNetwork.Services.ProgrammingLanguages.ProgrammingLanguages.Models
{
    public class UpdateProgrammingLanguageModel
    {
        public string Name { get; set; }
    }
    public class UpdateProgrammingLanguageModelProfile : Profile
    {
        public UpdateProgrammingLanguageModelProfile()
        {
            CreateMap<UpdateProgrammingLanguageModel, ProgrammingLanguage>();
        }
    }
    public class UpdateProgrammingLanguageModelValidator : AbstractValidator<UpdateProgrammingLanguageModel>
    {
        public UpdateProgrammingLanguageModelValidator(IDbContextFactory<MainDbContext> contextFactory)
        {
            RuleFor(x => x.Name).ProgrammingLanguageName();
        }
    }
}
