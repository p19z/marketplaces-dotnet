using Microsoft.EntityFrameworkCore;

namespace MarketplaceObjects
{
    public class MarketplaceContext : DbContext
    {
        public DbSet<Marketplace> Marketplaces { get; set; }
        public DbSet<User> Users { get; set; }
        public string DbPath { get; }

        public MarketplaceContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "marketplaces.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
