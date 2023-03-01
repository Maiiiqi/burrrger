using BurgerSystem.Ability.Docking.UserApp;
using BurgerSystem.Ability.Docking.UserApp.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BurgerSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // solve cross-origin problem
    [EnableCors("any")]
    public class RegisterController: BaseController
    {
        public IUserService UserService { get; set; }
        [HttpPost]
        public async Task<bool> RegisterUser(UserCreateDto createDto)
        {
            return await UserService.RegisterUser(createDto);
        }
    }
}
