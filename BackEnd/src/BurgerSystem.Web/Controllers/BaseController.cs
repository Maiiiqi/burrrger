using BurgerSystem.Ability.Docking.UserApp.Dto;
using BurgerSystem.Web.Filters;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BurgerSystem.Web.Controllers
{
    // base class which sets some common properties

    // required attribute
    [ApiController]
    [Route("api/[controller]")]
    // cross origin policy
    [EnableCors("any")]
    // action filter
    [TypeFilter(typeof(CustomerActionFilterAttribute))]
    public class BaseController: ControllerBase
    {
        // property injection for cache
        public IMemoryCache MemoryCache { get; set; }

        // get loginsuccessdto from httpcontext
        public LoginSuccessDto LoginSuccessInfo => HttpContext.Items["loginSuccessInfo"] as LoginSuccessDto;
    }
}
