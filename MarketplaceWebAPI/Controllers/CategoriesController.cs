using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketplaceObjects;

namespace MarketplaceWebAPI.Controllers.TESTONLY
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly MarketplaceDbCtx _context;
        private readonly ILogger<MarketplaceCtrl> _logger;

        public CategoriesController(
            MarketplaceDbCtx context,
            ILogger<MarketplaceCtrl> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        [HttpGet(Name = "GetCategories")]
        public List<Category>? Get()
        {
            _logger.LogInformation("List<Category>? Get()");
            var mp = MarketplaceCtrl.GetMarketplace(_context, _logger);
            return mp.Categories.ToList();
        }

        /*
        // GET api/v1/[controller]/items[?pageSize=3&pageIndex=10]
        [HttpGet(Name = "GetCategoriesList")]
        public IEnumerable<Category> GetCategoriesList()
        {
            using (var db = new MarketplaceContext())
            {
                var marketplace = Get();
                return marketplace.Categories;
            }
        }
        */
    }
}