using MarketplaceObjects;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceSQLAdminCLI
{
    internal static class FillDb
    {
        internal static void AddSampleData_S1E1v0(MarketplaceSQLContext db)
        {
            // Note: This sample requires the database to be created before running.
            // Console.WriteLine($"Database path: {db.DbPath}."); // f/ Sqlite

            // Create
            Console.WriteLine("Creating a super user");
            db.Add(new User { Email = "su", Password = "su", UserAlias = "SuperUser" });

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
        internal static void CreateCustomViews_v0(MarketplaceSQLContext db)
        {
            // Note: This sample requires the database to be created before running.
            // Console.WriteLine($"Database path: {db.DbPath}."); // f/ Sqlite

            //db.Database.ExecuteSqlRaw(
            //    @"CREATE VIEW View_BlogPostCounts AS
            //    SELECT b.Name, Count(p.PostId) as PostCount
            //    FROM Blogs b
            //    JOIN Posts p on p.BlogId = b.BlogId
            //    GROUP BY b.Name");
            db.Database.ExecuteSqlRaw(
                @"CREATE VIEW View_AllObjectsCounts AS
                SELECT 'MarketplacesCount' as CounterName
		                , Count(*) as CounterValue
                                FROM Marketplaces UNION ALL
                SELECT 'CategoriesCount' as CounterName
		                , Count(*) as CounterValue
                                FROM Categories UNION ALL
                SELECT 'OffersCount' as CounterName
		                , Count(*) as CounterValue
                                FROM Offers UNION ALL
                SELECT 'OrdersCount' as CounterName
		                , Count(*) as CounterValue
                                FROM Orders UNION ALL
                SELECT 'UsersCount' as CounterName
		                , Count(*) as CounterValue
                                FROM Users");
        }
    }
}
