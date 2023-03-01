using BurgerSystem.Ability.Docking.StoreApp;
using BurgerSystem.Ability.Docking.StoreApp.Dto;
using BurgerSystem.Web.Filters;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BurgerSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // solve cross-origin problem
    [EnableCors("any")]
    public class StoreController : BaseController
    {
        // DI
        public IStoreService StoreService { get; set; }

        // APIs
        // get all stores
        [HttpGet("AllStores")]
        public async Task<List<StoreDto>> GetStoresAsync()
        {
            return await StoreService.GetStoresAsync();
        }

        // get total count
        [HttpGet("Count")]
        public async Task<int> GetTotalCountAsync()
        {
            return await StoreService.GetTotalCountAsync();
        }

        // get one store
        [HttpGet("{id}")]
        [TypeFilter(typeof(CustomerResourceFilterAttribute))]
        public async Task<StoreDto> GetOneStoreAsync(int id)
        {
            return await StoreService.GetOneStoreAsync(id);
        }
    }
}
