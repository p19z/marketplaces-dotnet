using Microsoft.AspNetCore.Mvc;
using MarketplaceObjects;

namespace MarketplaceWebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly MarketplaceDbCtx _context;

        public UserController(
            MarketplaceDbCtx context,
            ILogger<MarketplaceCtrl> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet(Name = "GetUserFromId")]
        public User? Get()
        {
            return MarketplaceCtrl.GetUserFromId(1, _context);
        }
    }
}