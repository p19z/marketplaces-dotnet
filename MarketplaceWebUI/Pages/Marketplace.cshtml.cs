using MarketplaceObjects;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketplaceWebUI.Pages
{
    public class MarketplaceModel : PageModel
    {
        public readonly string Title;
        public readonly ICollection<Category> Categories;

        private readonly MpSvcs svcs;
        public MarketplaceModel(
            MarketplaceSQLContext context,
            ILogger<MarketplaceSQLContext> logger
            )
        {
            svcs = new MpSvcs(context, logger);
            var mp = MarketplaceCtrl.GetMarketplace(svcs);

            if (mp != null)
            {
                // Title
                if (mp.Title != null) Title = mp.Title;
                else Title = "";

                Categories = mp.Categories;
            }
            else
            {
                Title = "(no known marketplace atm)";
                Categories = new List<Category>();
            }
        }

        public void OnGet()
        {
        }
    }
}
