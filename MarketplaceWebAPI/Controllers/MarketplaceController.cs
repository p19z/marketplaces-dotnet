using Microsoft.AspNetCore.Mvc;
using MarketplaceObjects;

namespace MarketplaceWebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MarketplaceController : ControllerBase
    {
        private readonly MarketplaceDbCtx _context;
        private readonly ILogger<MarketplaceCtrl> _logger;

        public MarketplaceController(
            MarketplaceDbCtx context,
            ILogger<MarketplaceCtrl> logger
            )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        [HttpGet]
        public Marketplace Get()
        {
            _logger.LogInformation("WebAPI: Marketplace Get()");

            //using (var db = new MarketplaceContext())
            {
                //db.Configuration.ProxyCreationEnabled = true;
                //db.Configuration.LazyLoadingEnabled = true;
                //var marketplace = _context.Marketplaces

                //var marketplace = _context.Marketplaces
                //    .Include(x => x.Categories)
                //    .OrderBy(m => m.MarketplaceId)
                //    .First();
                //return marketplace;

                return MarketplaceCtrl.GetMarketplace(_context, _logger);
            }
        }
    }
}