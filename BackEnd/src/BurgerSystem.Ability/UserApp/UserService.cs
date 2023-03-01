using BurgerSystem.Ability.Docking.UserApp;
using BurgerSystem.Ability.Docking.UserApp.Dto;
using BurgerSystem.Domain.AccountInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youshow.Ace.Ability;
using Youshow.Ace.Domain.Repository;

namespace BurgerSystem.Ability.UserApp
{
    public  class UserService: AbilityServicer, IUserService
    {
        // get repo from database
        public IRepository<User> UserRepo { get; set; }
        // Login Check
        public async Task<LoginSuccessDto> CheckLogin(string userName, string password)
        {
            var user = await User.CheckLogin(userName, password, UserRepo);
            // login failed
            if(user == null)
            {
                return default;
            }
            var res = ModelMapper.Map<User, LoginSuccessDto>(user);
            res.Token = Guid.NewGuid().ToString();
            return res;
        }
        // User Register
        public async Task<bool> RegisterUser(UserCreateDto userCreateDto)
        {
            try
            {
                var user = ModelMapper.Map<UserCreateDto, User>(userCreateDto);
                user.CreateUser();
                await UserRepo.InsertAsync(user);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
    }
}
