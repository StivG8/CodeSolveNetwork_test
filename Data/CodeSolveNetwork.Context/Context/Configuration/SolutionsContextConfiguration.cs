using CodeSolveNetwork.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeSolveNetwork.Context.Context.Configuration
{
    public static class SolutionsContextConfiguration
    {
        public static void ConfigureSolutions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Solution>().ToTable("solutions");
            modelBuilder.Entity<Solution>().HasOne(x => x.Task).WithMany(x => x.Solutions);
        }
    }
}
