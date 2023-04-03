using MarketplaceObjects;

namespace MarketplaceSQLAdminCLI
{
    internal class QuerySqlServer : IQueryDb
    {
        private static List<RowsCounter> GetCounters(MarketplaceSQLContext db)
        {
            return db.AllObjectsCounts
                .ToList();
        }

        public void PrintCountersToConsole()
        {
            using (var db = new MarketplaceSqlServerContext())
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
