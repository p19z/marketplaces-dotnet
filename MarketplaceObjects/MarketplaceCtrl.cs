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
            logger?.LogInformation("!!!GetMarketplace!!!");
            return context.Marketplaces
                .Include(x => x.Categories)
                .OrderBy(m => m.MarketplaceId)
                .First();
        }
    }
}
