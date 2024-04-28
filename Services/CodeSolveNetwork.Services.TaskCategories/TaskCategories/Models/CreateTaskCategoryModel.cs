using AutoMapper;
using CodeSolveNetwork.Common.ValidationRules;
using CodeSolveNetwork.Context.Context;
using CodeSolveNetwork.Context.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CodeSolveNetwork.Services.TaskCategories
{
    public class CreateTaskCategoryModel
    {
        public string Name { get; set; }
    }

    public class CreateTaskCategoryModelProfile : Profile
    {
        public CreateTaskCategoryModelProfile()
        {
            CreateMap<CreateTaskCategoryModel, TaskCategory>()
                .AfterMap<CreateTaskCategoryModelActions>();
        }

        public class CreateTaskCategoryModelActions : IMappingAction<CreateTaskCategoryModel, TaskCategory>
        {
            private readonly IDbContextFactory<MainDbContext> contextFactory;

            public CreateTaskCategoryModelActions(IDbContextFactory<MainDbContext> contextFactory)
            {
                this.contextFactory = contextFactory;
            }

            public void Process(CreateTaskCategoryModel source, TaskCategory destination, ResolutionContext context)
            {
                using var db = contextFactory.CreateDbContext();
            }
        }
    }
    public class CreateTaskCategoryModelValidator : AbstractValidator<CreateTaskCategoryModel>
    {
        public CreateTaskCategoryModelValidator(IDbContextFactory<MainDbContext> contextFactory)
        {
            RuleFor(x => x.Name).TaskCategoryName();
        }
    }
}
