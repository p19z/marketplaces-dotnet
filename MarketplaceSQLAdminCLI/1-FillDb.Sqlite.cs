using MarketplaceObjects;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceSQLAdminCLI
{
    internal static partial class _0_InitDatabase
    {
        internal static void CoreSqliteDatabase_v0()
        {
            using (var db = new MarketplaceSqliteContext())
            {
                FillDb.CreateCustomViews_v0(db);
            }
        }
        internal static void FillSqliteDatabase_v0()
        {
            using (var db = new MarketplaceSqliteContext())
            {
                FillDb.AddSampleData_S1E1v0(db);
            }
        }
    }
    internal static partial class _0_CleanDatabase
    {
        internal static void DeleteSqliteCore_v0()
        {
            using (var db = new MarketplaceSqlServerContext())
            {
                CleanDb.DeleteCustomViews_v0(db);
            }
        }
        internal static void DeleteSqliteMarketplace_v0()
        {
            using (var db = new MarketplaceSqliteContext())
            {
                CleanDb.DeleteFirstMarketplace_v0(db);
                CleanDb.DeleteFirstUser_v0(db);
            }
        }
    }
}
