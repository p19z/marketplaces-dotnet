using MarketplaceObjects.Sqlite;
using Microsoft.Extensions.Logging;

namespace MarketplaceObjects
{
    public class MpSvcs
    {
        //public readonly MarketplaceDbCtx context;
        //public readonly ILogger<MarketplaceDbCtx> logger;

        public readonly MarketplaceSQLContext context;
        public readonly ILogger<MarketplaceSQLContext> logger;

        public MpSvcs(
            MarketplaceSQLContext contextIn,
            ILogger<MarketplaceSQLContext> loggerIn
            )
        {
            context = contextIn ?? throw new ArgumentNullException(nameof(contextIn));
            logger = loggerIn;
        }
    }
}
