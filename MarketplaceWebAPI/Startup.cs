using MarketplaceObjects;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceWebAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<MarketplaceContext>(
                options => options.UseSqlite($"Data Source={MarketplaceContext.BuildDbPath()}"));

            //db.Configuration.ProxyCreationEnabled = true;
            //db.Configuration.LazyLoadingEnabled = true;
        }
    }
}
