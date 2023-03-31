using MarketplaceObjects;

namespace MarketplaceAdminCLI
{
    internal static class FillDb
    {
        internal static void FillDb_v0(MarketplaceSQLContext db)
        {
            // Note: This sample requires the database to be created before running.
            // Console.WriteLine($"Database path: {db.DbPath}."); // f/ SQLite

            // Create
            Console.WriteLine("Creating a super user");
            db.Add(new User { Email = "su", Password = "su", Alias = "SuperUser" });

            // Create
            // Repeating db.SaveChanges(); for determinism. Prly not most efficient.
            Console.WriteLine("Inserting a new marketplace");
            db.Add(new Marketplace { Title = "Test-0a-0" });
            db.SaveChanges();

            // Read
            Console.WriteLine("Querying for first marketplace");
            var marketplaces = db.Marketplaces
                .OrderBy(m => m.MarketplaceId);
            var marketplace = marketplaces.First();

            // Update
            Console.WriteLine("Creating a categories list");
            marketplace.Title = "Test-0b-0";
            Category category;

            category = new Category { Name = "Cat. 1", Description = "First test category" };
            marketplace.Categories.Add(category);

            category = new Category { Name = "Cat. 2", Description = "Second test category" };
            marketplace.Categories.Add(category);

            category = new Category { Name = "Cat. 3", Description = "Third test category" };
            marketplace.Categories.Add(category);

            db.SaveChanges();

        }
        internal static void DeleteMarketplace_v0(MarketplaceSQLContext db) // UNTESTED
        {
            // Read
            Console.WriteLine("Querying for first marketplace");
            // TODO: Query for the categories too?
            var marketplaces = db.Marketplaces
                .OrderBy(m => m.MarketplaceId);
            var marketplace = marketplaces.First();

            // Delete
            Console.WriteLine("Delete the marketplace");
            db.Remove(marketplace);
            db.SaveChanges();
        }
    }
}
