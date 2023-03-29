using Microsoft.EntityFrameworkCore;

namespace MarketplaceObjects
{
    public class MarketplaceContext : DbContext
    {
        public DbSet<Marketplace> Marketplaces { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public string DbPath { get; }

        public static string BuildDbPath()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            return System.IO.Path.Join(path, "marketplaces.db");
        }

        public MarketplaceContext()
        {
            DbPath = BuildDbPath();
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
