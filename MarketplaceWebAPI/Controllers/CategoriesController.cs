using Microsoft.AspNetCore.Mvc;
using MarketplaceObjects;
using MarketplaceControl;

namespace MarketplaceWebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly MpSvcs svcs;
        public CategoriesController(
            MarketplaceDbCtx context,
            ILogger<MarketplaceDbCtx> logger
            )
        {
            svcs = new MpSvcs(context, logger);
            // ...
        }

        [HttpGet]
        public List<Category>? Get()
        {
            svcs.logger.LogInformation("List<Category>? Get()");
            return MarketplaceCtrl.GetAllCategories(svcs);
        }

        [HttpGet("byId")]
        public Category? Get(int id)
        {
            svcs.logger.LogInformation("Category? GetById()");
            return MarketplaceCtrl.GetCategoryById(svcs, id);
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