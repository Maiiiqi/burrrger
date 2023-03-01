using BurgerSystem.EntityFrameworkCore;
using BurgerSystem.Ability.Docking;
using Youshow.Ace.Ability;
using Youshow.Ace.AutoMapper;
using Youshow.Ace.Modularity;
using Youshow.Ace.Logger;
using Microsoft.Extensions.DependencyInjection;

namespace BurgerSystem.Ability;
[RelyOn(
    typeof(AceAbilityModule),
    typeof(AceAutoMapperModule),
    typeof(AceLoggerModule),
    typeof(BurgerSystemAbilityDockingModule),
    typeof(BurgerSystemEntityFrameworkCoreModule)
)]
public class BurgerSystemAbilityModule : AceModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var services = context.Services;
        services.AddAceLogger(
            opt=>opt.UseFile()
                    .UseElasticSearch(false)
        );
    }
}
