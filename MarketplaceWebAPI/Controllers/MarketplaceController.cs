using Microsoft.AspNetCore.Mvc;
using MarketplaceControl;
using MarketplaceObjects;
using Microsoft.EntityFrameworkCore;

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
            svcs.logger.LogInformation("Marketplace Get()");
            var mp = svcs.context.Marketplaces
                .OrderBy(m => m.MarketplaceId)
                .FirstOrDefault();
            return mp!; // REF. HttpNoContent if null
        }

        [HttpGet("byId")]
        public Marketplace? GetById(int id)
        {
            svcs.logger.LogInformation("Marketplace? GetById(int id)");
            return svcs.context.Marketplaces
                .Find(id);
        }

        [HttpGet("byId/withCategories")]
        public Marketplace? GetMarketplaceWithCategories(int id)
        {
            svcs.logger.LogInformation("Marketplace? GetMarketplaceWithCategories(int id)");
            return svcs.context.Marketplaces
                .Where(m => m.MarketplaceId == id)
                .Include(m => m.Categories)
                .FirstOrDefault();
        }

        [HttpGet("{id}/categories")]
        public List<Category> GetCategoriesListByMarketplaceId(int id)
        {
            svcs.logger.LogInformation("List<Category> GetCategoriesListByMarketplaceId(int id)");
            return svcs.context.Categories
                .Where(c => c.MarketplaceId == id)
                .ToList();
        }
    }
}