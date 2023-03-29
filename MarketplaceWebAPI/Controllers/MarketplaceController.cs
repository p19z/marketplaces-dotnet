using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketplaceObjects;

namespace MarketplaceWebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MarketplaceController : ControllerBase
    {
        //private readonly MarketplaceContext _marketplaceContext;
        //private readonly ILogger<MarketplaceController> _logger;

        public MarketplaceController(
            //MarketplaceContext context,
            //ILogger<MarketplaceController> logger
            )
        {
            //_marketplaceContext = context ?? throw new ArgumentNullException(nameof(context));
            //_logger = logger;
        }

        [HttpGet(Name = "GetMarketplace")]
        public Marketplace Get()
        {
            using (var db = new MarketplaceContext())
            {
                //db.Configuration.ProxyCreationEnabled = true;
                //db.Configuration.LazyLoadingEnabled = true;
                //var marketplace = _marketplaceContext.Marketplaces
                var marketplace = db.Marketplaces
                    .Include(x => x.Categories)
                    .OrderBy(m => m.MarketplaceId)
                    .First();
                return marketplace;
            }
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