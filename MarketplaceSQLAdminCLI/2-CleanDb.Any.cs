using MarketplaceObjects;

namespace MarketplaceSQLAdminCLI
{
    internal class CleanDb<TDbContext> : ICommonFillOrCleanDbOperations where TDbContext : MarketplaceSQLContext, IDisposable, new()
    {
        public void CoreDatabase_v0()
        {
            using (var db = new TDbContext())
            {
                CleanDb.DeleteCustomViews_v0(db);
            }
        }
        public void Population_v0()
        {
            using (var db = new TDbContext())
            {
                CleanDb.DeleteFirstMarketplace_v0(db);
                CleanDb.DeleteFirstUser_v0(db);
            }
        }
    }
}
