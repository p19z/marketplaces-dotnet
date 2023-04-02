using Microsoft.AspNetCore.Mvc;
using MarketplaceObjects;

namespace MarketplaceWebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MarketplaceController : ControllerBase
    {
        private readonly MpSvcs svcs;
        public MarketplaceController(
            MarketplaceDbCtx context,
            ILogger<MarketplaceDbCtx> logger
            )
        {
            svcs = new MpSvcs(context, logger);
            // ...
        }

        [HttpGet]
        public Marketplace Get()
        {
            svcs.logger.LogInformation("WebAPI: Marketplace Get()");
            var mp = MarketplaceCtrl.GetMarketplace(svcs);
            return mp!; // HttpNoContent
        }
    }
}