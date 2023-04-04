using MarketplaceObjects;

namespace MarketplaceSQLAdminCLI
{
    internal class FillDb<TDbContext> : ICommonFillOrCleanDbOperations where TDbContext : MarketplaceSQLContext, IDisposable, new()
    {
        public void CoreDatabase_v0()
        {
            using (var db = new TDbContext())
            {
                FillDb.CreateCustomViews_v0(db);
            }
        }
        public void Population_v0()
        {
            using (var db = new TDbContext())
            {
                FillDb.AddSampleData_S1E1v0(db);
            }
        }
    }
}
