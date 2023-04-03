using MarketplaceObjects;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceSQLAdminCLI
{
    internal class InitSqlServer : IFillDb
    {
        public void CoreDatabase_v0()
        {
            using (var db = new MarketplaceSqlServerContext())
            {
                FillDb.CreateCustomViews_v0(db);
            }
        }
        public void Population_v0()
        {
            using (var db = new MarketplaceSqlServerContext())
            {
                FillDb.AddSampleData_S1E1v0(db);
            }
        }
    }
    internal class CleanSqlServer : ICleanDb
    {
        public void CoreDatabase_v0()
        {
            using (var db = new MarketplaceSqlServerContext())
            {
                CleanDb.DeleteCustomViews_v0(db);
            }
        }
        public void Population_v0()
        {
            using (var db = new MarketplaceSqlServerContext())
            {
                CleanDb.DeleteFirstMarketplace_v0(db);
                CleanDb.DeleteFirstUser_v0(db);
            }
        }
    }
}
