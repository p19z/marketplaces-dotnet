using MarketplaceObjects;

namespace MarketplaceSQLAdminCLI
{
    internal static class QueryDb
    {
        internal static List<RowsCounter> GetCounters(MarketplaceSQLContext db)
        {
            return db.AllObjectsCounts
                .ToList();
        }

        internal static void PrintCountersToConsole()
        {
            using (var db = new MarketplaceSqliteContext())
            {
                var counters = GetCounters(db);
                foreach (var counter in counters)
                {
                    Console.Write(counter.CounterName + ": ");
                    Console.WriteLine(counter.CounterValue);
                }
            }
        }
    }
}
