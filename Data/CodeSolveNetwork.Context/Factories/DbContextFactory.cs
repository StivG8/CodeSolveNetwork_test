﻿using CodeSolveNetwork.Context.Context;
using Microsoft.EntityFrameworkCore;

namespace CodeSolveNetwork.Context.Factories
{
    public class DbContextFactory
    {
        private readonly DbContextOptions<MainDbContext> options;

        public DbContextFactory(DbContextOptions<MainDbContext> options)
        {
            this.options = options;
        }

        public MainDbContext Create()
        {
            return new MainDbContext(options);
        }
    }
}
