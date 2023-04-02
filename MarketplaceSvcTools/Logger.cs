using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace MarketplaceSvcTools
{
    public static class ConsoleConf /*: ILogger*/
    {
        public static Action<SimpleConsoleFormatterOptions> FormatOptns_v0 = (options) =>
        {
            options.SingleLine = true;
            options.TimestampFormat = "HH:mm:ss ";
            options.IncludeScopes = true;
        };
    }
}