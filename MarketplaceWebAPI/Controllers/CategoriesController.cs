using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketplaceObjects;

namespace MarketplaceWebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoriesController : ControllerBase
    {
        //private readonly MarketplaceContext _marketplaceContext;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(
            //MarketplaceContext context,
            ILogger<CategoriesController> logger)
        {
            //_marketplaceContext = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        [HttpGet(Name = "GetCategories")]
        public List<Category>? Get()
        {
            var ctl = new MarketplaceController();
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