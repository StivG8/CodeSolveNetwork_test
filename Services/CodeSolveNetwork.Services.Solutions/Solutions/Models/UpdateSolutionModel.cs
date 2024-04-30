using AutoMapper;
using CodeSolveNetwork.Context.Entities;
using FluentValidation;

namespace CodeSolveNetwork.Services.Solutions
{
    public class UpdateSolutionModel
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
    public class UpdateSolutionModelProfile : Profile
    {
        public UpdateSolutionModelProfile()
        {
            CreateMap<UpdateSolutionModel, Solution>();
        }
    }
    public class UpdateSolutionModelValidator : AbstractValidator<UpdateSolutionModel>
    {
        public UpdateSolutionModelValidator()
        {
            RuleFor(x => x.Code)
                 .MaximumLength(1000).WithMessage("Maximum length is 1000");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Maximum length is 1000");
        }
    }
}
