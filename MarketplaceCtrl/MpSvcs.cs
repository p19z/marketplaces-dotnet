using Microsoft.Extensions.Logging;
using MarketplaceControl;

namespace MarketplaceObjects
{
    public class MpSvcs
    {
        public readonly MarketplaceDbCtx context;
        public readonly ILogger<MarketplaceDbCtx> logger;

        public MpSvcs(
            MarketplaceDbCtx contextIn,
            ILogger<MarketplaceDbCtx> loggerIn
            )
        {
            context = contextIn ?? throw new ArgumentNullException(nameof(contextIn));
            logger = loggerIn;
        }
    }
}
