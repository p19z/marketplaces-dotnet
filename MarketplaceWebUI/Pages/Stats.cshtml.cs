using MarketplaceControl;
using MarketplaceObjects;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketplaceWebUI.Pages
{
    public class StatsModel : PageModel
    {
        public readonly string Title;
        public readonly List<RowsCounter> Counters;

        private readonly MpSvcs svcs;
        public StatsModel(
            MarketplaceDbCtx context,
            ILogger<MarketplaceDbCtx> logger
            )
        {
            svcs = new MpSvcs(context, logger);
            Title = "All Objects Count";
            Counters = MarketplaceCtrl.GetStatisticsV0(svcs);
        }

        public void OnGet()
        {
        }
    }
}
