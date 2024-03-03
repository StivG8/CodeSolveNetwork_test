using CodeSolveNetwork.Context.Context;
using CodeSolveNetwork.Context.Seeder.Seeds.Demo;
using CodeSolveNetwork.Context.Settings;
using CodeSolveNetwork.Services.UserAccount;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CodeSolveNetwork.Context.Seeder.Seeds
{
    public static class DbSeeder
    {
        private static IServiceScope ServiceScope(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<IServiceScopeFactory>()!.CreateScope();
        }

        private static MainDbContext DbContext(IServiceProvider serviceProvider)
        {
            return ServiceScope(serviceProvider)
                .ServiceProvider.GetRequiredService<IDbContextFactory<MainDbContext>>().CreateDbContext();
        }

        public static void Execute(IServiceProvider serviceProvider)
        {
            Task.Run(async () =>
            {
                await AddDemoData(serviceProvider);
                await AddAdministrator(serviceProvider);
            })
                .GetAwaiter()
                .GetResult();
        }

        private static async Task AddDemoData(IServiceProvider serviceProvider)
        {
            using var scope = ServiceScope(serviceProvider);
            if (scope == null)
                return;

            var settings = scope.ServiceProvider.GetService<DbSettings>();
            if (!(settings.Init?.AddDemoData ?? false))
                return;

            await using var context = DbContext(serviceProvider);

            if (await context.Tasks.AnyAsync())
                return;

            await context.Tasks.AddRangeAsync(new DemoHelper().GetTasks);

            await context.SaveChangesAsync();
        }

        private static async Task AddAdministrator(IServiceProvider serviceProvider)
        {
            using var scope = ServiceScope(serviceProvider);
            if (scope == null)
                return;

            var settings = scope.ServiceProvider.GetService<DbSettings>();
            if (!(settings.Init?.AddAdministrator ?? false))
                return;

            var userAccountService = scope.ServiceProvider.GetService<IUserAccountService>();

            if (!(await userAccountService.IsEmpty()))
                return;

            await userAccountService.Create(new RegisterUserAccountModel()
            {
                Name = settings.Init.Administrator.Name,
                Email = settings.Init.Administrator.Email,
                Password = settings.Init.Administrator.Password,
            });
        }
    }
}
