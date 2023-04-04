using Microsoft.AspNetCore.Mvc;
using MarketplaceObjects;
using MarketplaceControl;

namespace MarketplaceWebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly MpSvcs svcs;
        public UserController(
            MarketplaceDbCtx context,
            ILogger<MarketplaceDbCtx> logger
            )
        {
            svcs = new MpSvcs(context, logger);
            // ...
        }

        [HttpGet("withOffersAndOrders")]
        public User? Get()
        {
            return MarketplaceCtrl.GetAccountInfoFromUserId_v0(svcs, 1);
        }
    }
}