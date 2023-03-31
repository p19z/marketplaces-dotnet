using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MarketplaceObjects
{
    public static class MarketplaceCtrl
    {
        /*
        private readonly MpSvcs svcs;
        public <YourStuff>(
            MarketplaceDbCtx context,
            ILogger<MarketplaceDbCtx> logger
            )
        {
            svcs = new MpSvcs(context, logger);
            // ...
        }
        */

        public static Marketplace GetMarketplace(MpSvcs svcs)
        {
            svcs.logger?.LogInformation("[ctl] !!!GetMarketplace!!!");
            return svcs.context.Marketplaces
                .Include(x => x.Categories)
                .OrderBy(m => m.MarketplaceId)
                .First();
        }

        public static List<Category> GetAllCategories(MpSvcs svcs)
        {
            //logger?.LogInformation("[ctl] !!!GetMarketplace!!!");
            return svcs.context.Categories
                .OrderBy(m => m.CategoryId)
                .ToList();
        }

        public static Category? GetCategoryById(MpSvcs svcs, int categoryId)
        {
            //logger?.LogInformation("[ctl] !!!GetMarketplace!!!");
            return svcs.context.Categories
                .Where(c => c.CategoryId == categoryId)
                .FirstOrDefault();
        }

        public static User? GetAccountInfoFromUserId_v0(MpSvcs svcs, int userId)
        {
            //logger?.LogInformation($"[ctl] !!!GetUser( {userId} )!!!");
            return svcs.context.Users
                .Include(x => x.Offers)
                .Include(x => x.Orders)
                .Where(u => u.UserId == userId)
                .FirstOrDefault();
        }
    }
}
