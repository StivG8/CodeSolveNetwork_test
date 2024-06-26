﻿using CodeSolveNetwork.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeSolveNetwork.Context.Context.Configuration
{
    public static class TasksContextConfiguration
    {
        public static void ConfigureTasks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Task>().ToTable("tasks");
            modelBuilder.Entity<Entities.Task>().HasOne(x => x.Category).WithMany(x => x.Tasks)
                .HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entities.Task>().HasOne(x => x.Language).WithMany(x => x.Tasks)
                .HasForeignKey(x=>x.ProgrammingLanguageId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
