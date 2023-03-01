using BurgerSystem.Ability.Docking.StoreApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youshow.Ace.Ability.Services;

namespace BurgerSystem.Ability.Docking.StoreApp
{
    public interface IStoreService: IAbilityServicer
    {
        Task<List<StoreDto>> GetStoresAsync();
        Task<int> GetTotalCountAsync();
        Task<StoreDto> GetOneStoreAsync(int id);
    }
}
