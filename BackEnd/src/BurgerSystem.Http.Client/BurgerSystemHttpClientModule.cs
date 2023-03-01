using BurgerSystem.Ability.Docking;
using Microsoft.Extensions.DependencyInjection;
using Youshow.Ace.Http.Client;
using Youshow.Ace.Modularity;

namespace BurgerSystem.Http.Client;
[RelyOn(
        typeof(AceHttpClientModule)
)]
public class BurgerSystemHttpClientModule : AceModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAceHttpClient(opt =>
        {
           opt.AddRemoteModule<BurgerSystemAbilityDockingModule>("Default");
        });
    }

}
