using CodeSolveNetwork.Common.Helpers;
using CodeSolveNetwork.Common.Validator;
using FluentValidation.AspNetCore;

namespace CodeSolveNetwork.Api.Configuration
{
    public static class ValidatorConfiguration
    {
        public static IServiceCollection AddAppValidator(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation(opt => { opt.DisableDataAnnotationsValidation = true; });

            ValidatorsRegisterHelper.Register(services);

            services.AddSingleton(typeof(IModelValidator<>), typeof(ModelValidator<>));

            return services;
        }
    }
}
