// See https://aka.ms/new-console-template for more information
using MarketplaceSQLAdminCLI;

if (args.Length > 0)
{
    foreach (var arg in args)
    {
        Console.WriteLine($"Argument={arg}");
        switch (arg) {

            //
            // CORE
            //
            case "initCoreSqlite":
                new InitSqlite().CoreDatabase_v0();
                break;
            case "deleteCoreSqlite":
                new CleanSqlite().CoreDatabase_v0();
                break;
            case "initCoreSqlServer":
                new InitSqlServer().CoreDatabase_v0();
                break;
            case "deleteCoreSqlServer":
                new InitSqlServer().CoreDatabase_v0();
                break;

            //
            // POPULATE
            //
            case "populateSqlite":
                new InitSqlite().Population_v0();
                break;
            case "deleteSqliteContent":
                new CleanSqlite().Population_v0();
                break;
            case "populateSqlServer":
                new InitSqlServer().Population_v0();
                break;
            case "deleteSqlServerContent":
                new CleanSqlServer().Population_v0();
                break;

            //
            // OTHER
            //
            case "query":
            case "statsSqlite":
                new QuerySqlite().PrintCountersToConsole();
                break;
            case "statsSqlServer":
                new QuerySqlServer().PrintCountersToConsole();
                break;
        }
    }
}
else
{
    Console.WriteLine("No arguments");
}