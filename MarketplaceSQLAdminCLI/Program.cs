// See https://aka.ms/new-console-template for more information
using MarketplaceSQLAdminCLI;

if (args.Length > 0)
{
    foreach (var arg in args)
    {
        Console.WriteLine($"Argument={arg}");
        switch (arg) {

            case "coreSqliteInit":
                _0_InitDatabase.CoreSqliteDatabase_v0();
                break;
            case "coreSqlServerInit":
                _0_InitDatabase.CoreSqlServerDatabase_v0();
                break;
            case "coreSqliteDelete":
                _0_CleanDatabase.DeleteSqliteCore_v0();
                break;
            case "coreSqlServerDelete":
                _0_CleanDatabase.DeleteSqlServerCore_v0();
                break;

            case "populateSqlite0x-0":
                Console.WriteLine("_0x_InitDatabase.InitSqliteDatabase_v0!");
                _0_InitDatabase.FillSqliteDatabase_v0();
                break;
            case "populateSqlServer0x-0":
                Console.WriteLine("_0x_InitDatabase.InitSqlServerDatabase_v0!");
                _0_InitDatabase.FillSqlServerDatabase_v0();
                break;
            case "deleteSqliteContent0x-0":
                Console.WriteLine("_0x_CleanDatabase.DeleteSqliteMarketplace_v0!");
                _0_CleanDatabase.DeleteSqliteMarketplace_v0();
                break;
            case "deleteSqlServerContent0x-0":
                Console.WriteLine("_0x_CleanDatabase.DeleteSqlServerMarketplace_v0!");
                _0_CleanDatabase.DeleteSqlServerMarketplace_v0();
                break;

            case "stats":
            case "query":
                QueryDb.PrintCountersToConsole();
                break;
        }
    }
}
else
{
    Console.WriteLine("No arguments");
}