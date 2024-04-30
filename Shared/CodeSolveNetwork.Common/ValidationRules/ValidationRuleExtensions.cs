using FluentValidation;

namespace CodeSolveNetwork.Common.ValidationRules
{
    public static class ValidationRuleExtensions
    {
        public static IRuleBuilderOptions<T, string> ProgrammingLanguageName<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(20).WithMessage("Maximum length is 20");
        }
        public static IRuleBuilderOptions<T, string> TaskCategoryName<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(2).WithMessage("Minimum length is 2")
                .MaximumLength(20).WithMessage("Maximum length is 20");
        }
        public static IRuleBuilderOptions<T, string> TaskTitle<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Title is required")
                .MinimumLength(2).WithMessage("Minimum length is 2")
                .MaximumLength(20).WithMessage("Maximum length is 20");
        }
    }
}
