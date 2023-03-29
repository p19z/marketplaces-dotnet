using MarketplaceObjects;

namespace MarketplacesAdminCLI
{
    internal static class _0_InitDatabase
    {
        internal static void InitDatabase_v0()
        {
            using (var db = new MarketplacesContext())
            {

                // Note: This sample requires the database to be created before running.
                Console.WriteLine($"Database path: {db.DbPath}.");

                // Create
                Console.WriteLine("Inserting a new marketplace");
                db.Add(new Marketplace { Title = "Test-0a-0" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for first marketplace");
                var marketplace = db.Marketplaces
                    .OrderBy(m => m.MarketplaceId)
                    .First();

                // Update
                Console.WriteLine("Creating a categories list");
                marketplace.Title = "Test-0b-0";
                Category category;

                category = new Category { Title = "Cat. 1", Content = "First test category" };
                marketplace.Categories.Add(category);

                category = new Category { Title = "Cat. 2", Content = "Second test category" };
                marketplace.Categories.Add(category);

                category = new Category { Title = "Cat. 3", Content = "Third test category" };
                marketplace.Categories.Add(category);
                db.SaveChanges();

                /*
                // Delete
                Console.WriteLine("Delete the marketplace");
                db.Remove(marketplace);
                db.SaveChanges();
                */
            }
        }
    }
}
