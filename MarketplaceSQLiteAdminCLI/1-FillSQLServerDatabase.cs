using MarketplaceObjects;

namespace MarketplaceAdminCLI
{
    internal static partial class _0_InitDatabase
    {
        internal static void FillSqlServerDatabase_v0()
        {
            using (var db = new MarketplaceSqlServerContext())
            {
                FillDb.FillDb_v0(db);
            }
        }

        internal static void DeleteSqlServerMarketplace_v0()
        {
            using (var db = new MarketplaceSqlServerContext())
            {
                FillDb.DeleteMarketplace_v0(db);
            }
        }
    }
}
