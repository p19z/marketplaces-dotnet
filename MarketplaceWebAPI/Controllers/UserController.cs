using Microsoft.AspNetCore.Mvc;
using MarketplaceObjects;

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

        [HttpGet(Name = "GetAccountInfoFromUserId_v0")]
        public User? Get()
        {
            return MarketplaceCtrl.GetAccountInfoFromUserId_v0(svcs, 1);
        }

        [HttpGet("byId")]
        public User? Get(int id)
        {
            svcs.logger.LogInformation("List<Category>? GetById()");
            return MarketplaceCtrl.GetAccountInfoFromUserId_v0(svcs, id);
        }

    }
}