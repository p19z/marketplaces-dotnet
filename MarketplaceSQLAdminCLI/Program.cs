// See https://aka.ms/new-console-template for more information
using MarketplaceSQLAdminCLI;
using MarketplaceObjects.Sqlite;
using MarketplaceObjects.SqlServer;

if (args.Length > 0)
{
    foreach (var arg in args)
    {
        Console.WriteLine($"Argument={arg}");
        switch (arg) {

            //
            // CORE
            //
            case "sl-initCore":
                new FillDb<SqliteCtx>().CoreDatabase_v0();
                break;
            case "sl-removeCore":
                new CleanDb<SqliteCtx>().CoreDatabase_v0();
                break;
            case "ss-initCore":
                new FillDb<SqlServerCtx>().CoreDatabase_v0();
                break;
            case "ss-removeCore":
                new CleanDb<SqlServerCtx>().CoreDatabase_v0();
                break;

            //
            // POPULATE
            //
            case "sl-populate":
                new FillDb<SqliteCtx>().Population_v0();
                break;
            case "sl-depopulate":
                new CleanDb<SqliteCtx>().Population_v0();
                break;
            case "ss-populate":
                new FillDb<SqlServerCtx>().Population_v0();
                break;
            case "ss-depopulate":
                new CleanDb<SqlServerCtx>().Population_v0();
                break;

            //
            // OTHER
            //
            case "sl-stats":
                new QueryDb<SqliteCtx>().PrintCountersToConsole();
                break;
            case "ss-stats":
                new QueryDb<SqlServerCtx>().PrintCountersToConsole();
                break;
        }
    }
}
else
{
    Console.WriteLine("No arguments");
}