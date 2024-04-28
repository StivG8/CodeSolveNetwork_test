using AutoMapper;
using CodeSolveNetwork.Common.ValidationRules;
using CodeSolveNetwork.Context.Entities;
using FluentValidation;
using Task = CodeSolveNetwork.Context.Entities.Task;

namespace CodeSolveNetwork.Services.Tasks
{
    public class UpdateTaskModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class UpdateTaskModelProfile : Profile
    {
        public UpdateTaskModelProfile()
        {
            CreateMap<UpdateTaskModel, Task>();
        }
    }
    public class UpdateTaskModelValidator : AbstractValidator<UpdateTaskModel>
    {
        public UpdateTaskModelValidator()
        {
            RuleFor(x => x.Title).TaskTitle();
         
            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Maximum length is 1000");
        }
    }
}
