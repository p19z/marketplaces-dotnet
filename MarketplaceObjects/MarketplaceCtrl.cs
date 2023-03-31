using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MarketplaceObjects
{
    public class MarketplaceCtrl
    {
        private readonly MarketplaceSQLContext _context;
        private readonly ILogger<MarketplaceCtrl> _logger;
        
        public MarketplaceCtrl(
            MarketplaceSQLContext context,
            ILogger<MarketplaceCtrl> logger
            )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        public static Marketplace GetMarketplace(MarketplaceSQLContext context, ILogger<MarketplaceCtrl>? logger)
        {
            logger?.LogInformation("[ctl] !!!GetMarketplace!!!");
            return context.Marketplaces
                .Include(x => x.Categories)
                .OrderBy(m => m.MarketplaceId)
                .First();
        }

        public static List<Category> GetAllCategories(MarketplaceSQLContext context)
        {
            //logger?.LogInformation("[ctl] !!!GetMarketplace!!!");
            return context.Categories
                .OrderBy(m => m.CategoryId)
                .ToList();
        }

        public static Category? GetCategoryById(int categoryId, MarketplaceSQLContext context)
        {
            //logger?.LogInformation("[ctl] !!!GetMarketplace!!!");
            return context.Categories
                .Where(c => c.CategoryId == categoryId)
                .FirstOrDefault();
        }

        public static User? GetUserFromId(int userId, MarketplaceSQLContext context)
        {
            //logger?.LogInformation($"[ctl] !!!GetUser( {userId} )!!!");
            return context.Users
                .Include(x => x.Offers)
                    .ThenInclude(x => x.CategoryId) // TODO x.OrdersCount, x.Orders
                .Include(x => x.Orders)
                    .ThenInclude(x => x.OfferId) // TODO x.Offers, x.OffersCount
                        // .ThenInclude(x => x!.Category) // warning CS8602: Dereference of a possibly null reference.
                .Where(u => u.UserId == userId)
                .FirstOrDefault();
        }
    }
}
