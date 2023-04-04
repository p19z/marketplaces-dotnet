using Microsoft.EntityFrameworkCore;

namespace MarketplaceObjects.SqlServer
{
    public class MarketplaceDbCtx : SqlServerCtx
    {
    }

    public class SqlServerCtx : MarketplaceSQLContext
    {
        public const string DbName = "marketplaces";

        public SqlServerCtx()
        {
        }

        // REF 230329-2
        // C:\SQL2019\Express_ENU
        // C:\Program Files\Microsoft SQL Server\150\SSEI\Resources
        // Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Server=localhost\\SQLEXPRESS;Database={DbName};Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
