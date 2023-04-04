using MarketplaceObjects;

namespace MarketplaceSQLAdminCLI
{
    internal class QueryDb<TDbContext> : ICommonQueryDbOperations where TDbContext : MarketplaceSQLContext, IDisposable, new()
    {
        private static List<RowsCounter> GetCounters(TDbContext db)
        {
            return db.AllObjectsCounts
                .ToList();
        }

        public void PrintCountersToConsole()
        {
            using (var db = new TDbContext())
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
