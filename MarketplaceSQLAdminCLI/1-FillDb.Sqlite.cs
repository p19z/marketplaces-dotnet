using MarketplaceObjects;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceSQLAdminCLI
{
    internal static partial class _0_InitDatabase
    {
        internal static void FillSqliteDatabase_v0()
        {
            using (var db = new MarketplaceSqliteContext())
            {
                FillDb.AddSampleData_S1E1v0(db);
                FillDb.Create_AllObjectsCounts_View_S1E1v0(db);
            }
        }
    }
    internal static partial class _0_CleanDatabase
    {
        internal static void DeleteSqliteMarketplace_v0()
        {
            using (var db = new MarketplaceSqliteContext())
            {
                CleanDb.DeleteFirstMarketplace_v0(db);
                CleanDb.DeleteFirstUser_v0(db);
                CleanDb.DeleteCustomViews_v0(db);
            }
        }
    }
}
