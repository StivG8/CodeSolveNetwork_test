using AutoMapper;
using CodeSolveNetwork.Common.ValidationRules;
using CodeSolveNetwork.Context.Entities;
using FluentValidation;

namespace CodeSolveNetwork.Services.TaskCategories
{
    public class UpdateTaskCategoryModel
    {
        public string Name { get; set; }

    }
    public class UpdateTaskCategoryModelProfile : Profile
    {
        public UpdateTaskCategoryModelProfile()
        {
            CreateMap<UpdateTaskCategoryModel, TaskCategory>();
        }
    }
    public class UpdateTaskCategoryModelValidator : AbstractValidator<UpdateTaskCategoryModel>
    {
        public UpdateTaskCategoryModelValidator()
        {
            RuleFor(x => x.Name).TaskCategoryName();
        }
    }
}
