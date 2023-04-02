using MarketplaceObjects;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceSQLAdminCLI
{
    internal static partial class _0_InitDatabase
    {
        internal static void FillSqlServerDatabase_v0()
        {
            using (var db = new MarketplaceSqlServerContext())
            {
                FillDb.AddSampleData_S1E1v0(db);
                FillDb.Create_AllObjectsCounts_View_S1E1v0(db);
            }
        }
    }
    internal static partial class _0_CleanDatabase
    {
        internal static void DeleteSqlServerMarketplace_v0()
        {
            using (var db = new MarketplaceSqlServerContext())
            {
                CleanDb.DeleteFirstMarketplace_v0(db);
                CleanDb.DeleteFirstUser_v0(db);
                CleanDb.DeleteCustomViews_v0(db);
            }
        }
    }
}
