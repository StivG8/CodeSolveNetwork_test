
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
    }
}
