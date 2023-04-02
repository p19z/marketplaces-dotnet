using Microsoft.EntityFrameworkCore;
// requires Microsoft.EntityFrameworkCore.Relational;

namespace MarketplaceObjects
{
    public class MarketplaceSQLContext : DbContext
    {
        public DbSet<Marketplace> Marketplaces { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Order> Orders { get; set; }

        // Views
        public DbSet<RowsCounter> AllObjectsCounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<RowsCounter>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("View_AllObjectsCounts");
                        eb.Property(v => v.CounterName).HasColumnName("CounterName");
                        eb.Property(v => v.CounterValue).HasColumnName("CounterValue");
                    });
        }
    }
}
