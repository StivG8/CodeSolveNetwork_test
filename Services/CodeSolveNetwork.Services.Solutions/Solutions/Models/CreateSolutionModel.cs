using AutoMapper;
using CodeSolveNetwork.Context.Context;
using CodeSolveNetwork.Context.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CodeSolveNetwork.Services.Solutions
{
    public class CreateSolutionModel
    {
        public Guid TaskId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
    public class CreateSolutionModelProfile : Profile
    {
        public CreateSolutionModelProfile()
        {
            CreateMap<CreateSolutionModel, Solution>()
                .ForMember(dest => dest.TaskId, opt => opt.Ignore())
                .AfterMap<CreateSolutionModelActions>();
        }

        public class CreateSolutionModelActions : IMappingAction<CreateSolutionModel, Solution>
        {
            private readonly IDbContextFactory<MainDbContext> contextFactory;

            public CreateSolutionModelActions(IDbContextFactory<MainDbContext> contextFactory)
            {
                this.contextFactory = contextFactory;
            }

            public void Process(CreateSolutionModel source, Solution destination, ResolutionContext context)
            {
                using var db = contextFactory.CreateDbContext();

                var task = db.Tasks.FirstOrDefault(x => x.Uid == source.TaskId);

                destination.TaskId = task.Id;
            }
        }
    }
    public class CreateSolutionModelValidator : AbstractValidator<CreateSolutionModel>
    {
        public CreateSolutionModelValidator(IDbContextFactory<MainDbContext> contextFactory)
        {
            RuleFor(x => x.TaskId)
                .NotEmpty().WithMessage("Task is required")
                .Must((id) =>
                {
                    using var context = contextFactory.CreateDbContext();
                    var found = context.Tasks.Any(a => a.Uid == id);
                    return found;
                }).WithMessage("Task not found");

            RuleFor(x => x.Code)
                .MaximumLength(1000).WithMessage("Maximum length is 1000");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Maximum length is 1000");
        }
    }
}

