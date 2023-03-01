using BurgerSystem.Ability.Docking.UserApp;
using BurgerSystem.Ability.Docking.UserApp.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BurgerSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // solve cross-origin problem
    [EnableCors("any")]
    public class LoginController: BaseController
    {
        // Dependency Injection
        public IUserService UserService { get; set; }
        // API exposed to FrontEnd
        [HttpGet]
        public async Task<ActionResult<LoginSuccessDto>> CheckLogin(string userName, string password)
        {
            var res = await UserService.CheckLogin(userName, password);
            // check login failed
            if(res == null)
            {
                return new JsonResult(null)
                {
                    StatusCode = 202,
                    Value = "User Name or Password is wrong!"
                };
            }
            // set token to cache
            MemoryCache.Set(res.Token, res, TimeSpan.FromMinutes(5));
            return res;
        }
    }
}
