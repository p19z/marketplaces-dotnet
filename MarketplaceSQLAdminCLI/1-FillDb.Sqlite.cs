using MarketplaceObjects;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceSQLAdminCLI
{
    internal class InitSqlite : IFillDb
    {
        public void CoreDatabase_v0()
        {
            using (var db = new MarketplaceSqliteContext())
            {
                FillDb.CreateCustomViews_v0(db);
            }
        }
        public void Population_v0()
        {
            using (var db = new MarketplaceSqliteContext())
            {
                FillDb.AddSampleData_S1E1v0(db);
            }
        }
    }

    //
    // CLEAN
    //

    internal class CleanSqlite : ICleanDb
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
            using (var db = new MarketplaceSqliteContext())
            {
                CleanDb.DeleteFirstMarketplace_v0(db);
                CleanDb.DeleteFirstUser_v0(db);
            }
        }
    }
}
