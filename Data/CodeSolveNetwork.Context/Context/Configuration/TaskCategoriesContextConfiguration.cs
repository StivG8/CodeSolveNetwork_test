using CodeSolveNetwork.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeSolveNetwork.Context.Context.Configuration
{
    public static class TaskCategoriesContextConfiguration
    {
        public static void ConfigureTaskCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskCategory>().ToTable("task_categories");
        }
    }
}
