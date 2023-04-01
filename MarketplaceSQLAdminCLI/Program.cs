// See https://aka.ms/new-console-template for more information
using MarketplaceAdminCLI;

if (args.Length > 0)
{
    foreach (var arg in args)
    {
        Console.WriteLine($"Argument={arg}");
        switch (arg) {
            case "populateSQLite0x-0":
                Console.WriteLine("_0x_InitDatabase.InitSQLiteDatabase_v0!");
                _0_InitDatabase.FillSQLiteDatabase_v0();
                break;
            case "populateSqlServer0x-0":
                Console.WriteLine("_0x_InitDatabase.InitSqlServerDatabase_v0!");
                _0_InitDatabase.FillSqlServerDatabase_v0();
                break;
            case "deleteSQLiteContent0x-0":
                Console.WriteLine("_0x_CleanDatabase.DeleteSQLiteMarketplace_v0!");
                _0_CleanDatabase.DeleteSQLiteMarketplace_v0();
                break;
            case "deleteSqlServerContent0x-0":
                Console.WriteLine("_0x_CleanDatabase.DeleteSqlServerMarketplace_v0!");
                _0_CleanDatabase.DeleteSqlServerMarketplace_v0();
                break;
        }
    }
}
else
{
    Console.WriteLine("No arguments");
}