using AutoMapper;
using CodeSolveNetwork.Common.ValidationRules;
using CodeSolveNetwork.Context.Context;
using CodeSolveNetwork.Context.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Task = CodeSolveNetwork.Context.Entities.Task;

namespace CodeSolveNetwork.Services.Tasks
{
    public class CreateTaskModel
    {
        public Guid ProgrammingLanguageId { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class CreateTaskModelProfile : Profile
    {
        public CreateTaskModelProfile()
        {
            CreateMap<CreateTaskModel, Task>()
                .ForMember(dest => dest.ProgrammingLanguageId, opt => opt.Ignore())
                .ForMember(dest => dest.CategoryId, opt => opt.Ignore())
                .AfterMap<CreateTaskModelActions>();
        }

        public class CreateTaskModelActions : IMappingAction<CreateTaskModel, Task>
        {
            private readonly IDbContextFactory<MainDbContext> contextFactory;

            public CreateTaskModelActions(IDbContextFactory<MainDbContext> contextFactory)
            {
                this.contextFactory = contextFactory;
            }

            public void Process(CreateTaskModel source, Task destination, ResolutionContext context)
            {
                using var db = contextFactory.CreateDbContext();

                var programmingLanguage = db.ProgrammingLanguages.FirstOrDefault(x => x.Uid == source.ProgrammingLanguageId);
                destination.ProgrammingLanguageId = programmingLanguage.Id;

                var taskCategory = db.TaskCategories.FirstOrDefault(x => x.Uid == source.CategoryId);
                destination.CategoryId = taskCategory.Id;
            }
        }
    }
    public class CreateTaskModelValidator : AbstractValidator<CreateTaskModel>
    {
        public CreateTaskModelValidator(IDbContextFactory<MainDbContext> contextFactory)
        {
            RuleFor(x => x.ProgrammingLanguageId)
                .NotEmpty().WithMessage("Programming Language is required")
                .Must((id) =>
                {
                    using var context = contextFactory.CreateDbContext();
                    var found = context.ProgrammingLanguages.Any(a => a.Uid == id);
                    return found;
                }).WithMessage("Programming Language not found");
            
            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category is required")
                .Must((id) =>
                {
                    using var context = contextFactory.CreateDbContext();
                    var found = context.TaskCategories.Any(a => a.Uid == id);
                    return found;
                }).WithMessage("Category not found");

            RuleFor(x => x.Title).TaskTitle();

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Maximum length is 1000");
        }
    }
}
