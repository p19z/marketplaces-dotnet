using MarketplaceObjects;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceSQLAdminCLI
{
    internal static class CleanDb
    {
        internal static void DeleteFirstMarketplace_v0(MarketplaceSQLContext db)
        {
            // Read
            Console.WriteLine($"Querying for first marketplace");
            var marketplace = db.Marketplaces
                .OrderBy(m => m.MarketplaceId)
                .FirstOrDefault();

            if (marketplace == null)
            {
                Console.WriteLine("No marketplaces left. Nothing to delete.");
                return;
            }

            // Delete marketplace
            // + Cascade DELETE of Categories...
            Console.WriteLine($"Delete the marketplace {marketplace.MarketplaceId} from the database");
            db.Remove(marketplace);
            Console.WriteLine("Save changes");
            db.SaveChanges();

            Console.WriteLine($"Test runtime object marketplace.Title:");
            Console.WriteLine(marketplace.Title);
        }

        internal static void DeleteFirstUser_v0(MarketplaceSQLContext db)
        {
            // Read
            Console.WriteLine("Querying for first user");
            var user = db.Users
                .OrderBy(m => m.UserId)
                .FirstOrDefault();

            if (user == null)
            {
                Console.WriteLine("No users left. Nothing to delete.");
                return;
            }

            // Delete user
            // + Cascade DELETE of ???...
            Console.WriteLine($"Delete the user {user.UserId} from the database");
            db.Remove(user);
            Console.WriteLine("Save changes");
            db.SaveChanges();
        }

        internal static void DeleteCustomViews_v0(MarketplaceSQLContext db)
        {
            db.Database.ExecuteSqlRaw("DROP VIEW IF EXISTS View_AllObjectsCounts");
        }
    }
}
