﻿using CodeSolveNetwork.Context.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CodeSolveNetwork.Context.Setup
{
    public static class DbInitializer
    {
        public static void Execute(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetService<IServiceScopeFactory>()?.CreateScope();
            ArgumentNullException.ThrowIfNull(scope);

            var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<MainDbContext>>();
            using var context = dbContextFactory.CreateDbContext();
            context.Database.Migrate();
        }
    }
}
