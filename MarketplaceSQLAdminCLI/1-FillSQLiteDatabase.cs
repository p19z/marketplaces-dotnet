using MarketplaceObjects;

namespace MarketplaceAdminCLI
{
    internal static partial class _0_InitDatabase
    {
        internal static void FillSQLiteDatabase_v0()
        {
            using (var db = new MarketplaceSQLiteContext())
            {
                FillDb.FillDb_v0(db);
            }
        }

        internal static void DeleteSQLiteMarketplace_v0()
        {
            using (var db = new MarketplaceSQLiteContext())
            {
                FillDb.DeleteMarketplace_v0(db);
            }
        }
    }
}
