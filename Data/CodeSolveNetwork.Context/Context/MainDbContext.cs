﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CodeSolveNetwork.Context.Context.Configuration;
using CodeSolveNetwork.Context.Entities;

namespace CodeSolveNetwork.Context.Context
{
    public class MainDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<TaskCategory> TaskCategories { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureProgrammingLanguage();
            modelBuilder.ConfigureSolutions();
            modelBuilder.ConfigureSubscriptions();
            modelBuilder.ConfigureTaskCategories();
            modelBuilder.ConfigureTasks();
            modelBuilder.ConfigureUsers();
        }
    }
}
