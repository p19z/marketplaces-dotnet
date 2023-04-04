using Microsoft.EntityFrameworkCore;

namespace MarketplaceObjects.Sqlite
{
    public class MarketplaceDbCtx : SqliteCtx
    {
    }

    public class SqliteCtx : MarketplaceSQLContext
    {
        public const string DbName = "marketplaces";

        public string DbPath { get { return GetDbPath(); } }

        public SqliteCtx()
        {
        }

        public static string GetDbPath()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            return System.IO.Path.Join(path, $"{DbName}.db");
        }

        // REF 230329-1
        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
