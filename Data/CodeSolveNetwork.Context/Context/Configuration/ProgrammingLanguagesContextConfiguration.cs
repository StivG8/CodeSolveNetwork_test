using CodeSolveNetwork.Context.Entities;
using Microsoft.EntityFrameworkCore;


namespace CodeSolveNetwork.Context.Context.Configuration
{
    public static class ProgrammingLanguagesContextConfiguration
    {
        public static void ConfigureProgrammingLanguage(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>().ToTable("programming_languages");
        }
    }
}
