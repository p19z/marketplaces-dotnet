using MarketplaceObjects;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketplaceWebUI.Pages
{
    public class AccountModel : PageModel
    {
        public readonly User? InspectedUser;
        public readonly string? InspectedUserAlias;

        private readonly MpSvcs svcs;
        public AccountModel(
            MarketplaceSQLContext context,
            ILogger<MarketplaceSQLContext> logger
            )
        {
            svcs = new MpSvcs(context, logger);
            InspectedUser = MarketplaceCtrl.GetAccountInfoFromUserId_v0(svcs, 1);
            InspectedUserAlias = InspectedUser!.UserAlias;
            InspectedUserAlias = InspectedUserAlias ?? InspectedUser!.Email;
        }

        public void OnGet()
        {
        }
    }
}
