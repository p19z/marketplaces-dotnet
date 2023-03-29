using MarketplaceObjects;
using MarketplaceWebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketplaceWebUI.Pages
{
    public class MarketplaceModel : PageModel
    {
        public readonly Marketplace Marketplace;

        private readonly MarketplaceContext _context;
        private readonly ILogger<MarketplaceController> _logger;
        private readonly MarketplaceController? _ctl;

        public MarketplaceModel(
            MarketplaceContext context,
            ILogger<MarketplaceController> logger
            )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;

            _ctl = new MarketplaceController(_context, _logger);
            Marketplace = _ctl.Get();
        }

        public void OnGet()
        {
        }
    }
}
