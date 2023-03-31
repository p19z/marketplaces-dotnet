using MarketplaceObjects;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketplaceWebUI.Pages
{
    public class MarketplaceModel : PageModel
    {
        public readonly Marketplace Marketplace;

        private readonly MpSvcs svcs;
        public MarketplaceModel(
            MarketplaceDbCtx context,
            ILogger<MarketplaceDbCtx> logger
            )
        {
            svcs = new MpSvcs(context, logger);
            Marketplace = MarketplaceCtrl.GetMarketplace(svcs);
        }

        public void OnGet()
        {
        }
    }
}
