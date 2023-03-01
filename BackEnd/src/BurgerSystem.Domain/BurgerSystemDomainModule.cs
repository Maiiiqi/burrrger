using Youshow.Ace.Domain;
using Youshow.Ace.Modularity;

namespace BurgerSystem.Domain;
[RelyOn(
    typeof(AceDomainModule)
)]
public class BurgerSystemDomainModule : AceModule
{

}
