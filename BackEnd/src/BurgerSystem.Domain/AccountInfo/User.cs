using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youshow.Ace.Domain.Models;
using Youshow.Ace.Domain.Repository;

namespace BurgerSystem.Domain.AccountInfo
{
    public class User: BaseModel<int>
    {
        // User informaion
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? ImagePath { get; set; }
        public DateTime RegisterTime { get; set; }
        
        //Login Check
        public static async Task<User> CheckLogin(string userName, string password, IRepository<User> userRepo)
        {
            var user = await userRepo.GetAsync(u => u.UserName == userName &&  u.Password == password);
            return user;
        }
        public void CreateUser() 
        {
            this.RegisterTime = DateTime.Now;
        }
    }
}
