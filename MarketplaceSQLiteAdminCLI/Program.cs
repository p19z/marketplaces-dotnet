// See https://aka.ms/new-console-template for more information
using MarketplaceAdminCLI;

if (args.Length > 0)
{
    foreach (var arg in args)
    {
        Console.WriteLine($"Argument={arg}");
        if (arg == "hardcodedPopulateSQLite0x-0")
        {
            Console.WriteLine("_0x_InitDatabase.InitSQLiteDatabase_v0!");
            _0_InitDatabase.InitSQLiteDatabase_v0();
        }
    }
}
else
{
    Console.WriteLine("No arguments");
}