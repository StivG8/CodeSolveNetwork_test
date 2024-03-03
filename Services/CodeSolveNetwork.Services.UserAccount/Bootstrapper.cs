
using Microsoft.Extensions.DependencyInjection;

namespace CodeSolveNetwork.Services.UserAccount
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddUserAccountService(this IServiceCollection services)
        {
            services.AddScoped<IUserAccountService, UserAccountService>();  // userManager works with context in scope that's why we use scoped

            return services;
        }
    }
}
