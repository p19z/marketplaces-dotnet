using MarketplaceObjects;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceAdminCLI
{
    internal static partial class _0_InitDatabase
    {
        internal static void FillSQLiteDatabase_v0()
        {
            using (var db = new MarketplaceSQLiteContext())
            {
                FillDb.AddSampleData_S1E1v0(db);
                FillDb.Create_AllObjectsCounts_View_S1E1v0(db);
            }
        }
    }
    internal static partial class _0_CleanDatabase
    {
        internal static void DeleteSQLiteMarketplace_v0()
        {
            using (var db = new MarketplaceSQLiteContext())
            {
                CleanDb.DeleteFirstMarketplace_v0(db);
                CleanDb.DeleteFirstUser_v0(db);
                CleanDb.DeleteCustomViews_v0(db);
            }
        }
    }
}
