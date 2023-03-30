using Microsoft.EntityFrameworkCore;

namespace MarketplaceObjects
{
    public class MarketplaceSQLContext : DbContext
    {
        public DbSet<Marketplace> Marketplaces { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
