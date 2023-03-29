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
                db.Add(new Marketplace { Title = "Test-0b-0" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a marketplace");
                var marketplace = db.Marketplaces
                    .OrderBy(m => m.MarketplaceId)
                    .First();

                // Update
                Console.WriteLine("Updating the marketplace and adding a category");
                marketplace.Title = "Test-0c-0";
                var categoriesList = new CategoriesList();
                marketplace.CategoriesList = categoriesList;
                db.SaveChanges();

                // Update (BIS)
                var category = new Category { Title = "Cat. 1", Content = "First test category" };
                marketplace.CategoriesList.Categories.Add(category);
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
