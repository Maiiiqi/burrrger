using BurgerSystem.Ability.Docking.UserApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youshow.Ace.Ability.Services;

namespace BurgerSystem.Ability.Docking.UserApp
{
    public interface IUserService: IAbilityServicer
    {
        Task<LoginSuccessDto> CheckLogin(string userName, string password);
        Task<bool> RegisterUser(UserCreateDto userCreateDto);
    }
}
