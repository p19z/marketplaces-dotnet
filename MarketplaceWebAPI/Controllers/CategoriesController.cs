using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketplaceObjects;

namespace MarketplaceWebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly MarketplaceContext _context;
        private readonly ILogger<MarketplaceController> _logger;

        public CategoriesController(
            MarketplaceContext context,
            ILogger<MarketplaceController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        [HttpGet(Name = "GetCategories")]
        public List<Category>? Get()
        {
            _logger.LogInformation("List<Category>? Get()");
            var ctl = new MarketplaceController(_context, _logger);
            var mp = ctl.Get();
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