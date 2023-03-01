using BurgerSystem.Ability.Docking.StoreApp;
using BurgerSystem.Ability.Docking.StoreApp.Dto;
using BurgerSystem.Domain.StoreInfo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youshow.Ace.Ability;
using Youshow.Ace.Domain.Repository;

namespace BurgerSystem.Ability.StoreApp
{
    public class StoreService: AbilityServicer, IStoreService
    {
        // dependency injection for repo
        public IRepository<Store> StoreRepo { get; set; }

        // get all stores
        public async Task<List<StoreDto>> GetStoresAsync()
        {
            var storeList = await StoreRepo.OrderByDescending(x => x.StoreName).ToListAsync();
            var storeDtos = ModelMapper.Map<List<Store>, List<StoreDto>>(storeList);
            return storeDtos;
        }

        // get count of stores
        public async Task<int> GetTotalCountAsync()
        {
            return await StoreRepo.CountAsync();
        }

        // get one store
        public async Task<StoreDto> GetOneStoreAsync(int id)
        {
            var store = await StoreRepo.GetAsync(m => m.Id == id);
            var storeDto = ModelMapper.Map<Store, StoreDto>(store);
            return storeDto;
        }
    }
}
