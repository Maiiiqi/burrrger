using Microsoft.Extensions.DependencyInjection;
using BurgerSystem.Domain;
using Youshow.Ace.EntityFrameworkCore;
using Youshow.Ace.Modularity;

namespace BurgerSystem.EntityFrameworkCore;
[RelyOn(
    typeof(AceEntityFrameworkCoreModule),
    typeof(BurgerSystemDomainModule)
)]
public class BurgerSystemEntityFrameworkCoreModule : AceModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAceDbContext<BurgerSystemDbContext>(opt=>
        {
            opt.AddDefaultRepositories(true);
        });
        Configure<AceDbContextOptions>(opt=>{
            opt.UseMySQL();
        });
    }
}
