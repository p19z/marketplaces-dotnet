// See https://aka.ms/new-console-template for more information
using MarketplacesAdminCLI;

if (args.Length > 0)
{
    foreach (var arg in args)
    {
        Console.WriteLine($"Argument={arg}");
        if (arg == "hardcodedPopulate0x-0")
        {
            Console.WriteLine("_0x_InitDatabase.InitDatabase_v0!");
            _0_InitDatabase.InitDatabase_v0();
        }
    }
}
else
{
    Console.WriteLine("No arguments");
}