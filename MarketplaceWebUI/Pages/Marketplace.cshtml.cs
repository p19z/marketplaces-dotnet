using MarketplaceObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketplaceWebUI.Pages
{
    public class MarketplaceModel : PageModel
    {
        public readonly Marketplace Marketplace;

        private readonly MarketplaceSQLContext _context;
        private readonly ILogger<MarketplaceCtrl> _logger;

        public MarketplaceModel(
            MarketplaceSQLContext context,
            ILogger<MarketplaceCtrl> logger
            )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;

            //_ctl = new MarketplaceCtrl(_context, _logger);
            //Marketplace = _ctl.GetMarketplace();

            Marketplace = MarketplaceCtrl.GetMarketplace(_context, _logger);
        }

        public void OnGet()
        {
        }
    }
}
