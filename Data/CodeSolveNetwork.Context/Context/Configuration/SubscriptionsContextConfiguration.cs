using CodeSolveNetwork.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeSolveNetwork.Context.Context.Configuration
{
    public static class SubscriptionsContextConfiguration
    {
        public static void ConfigureSubscriptions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscription>().ToTable("subscriptions");
        }
    }
}
