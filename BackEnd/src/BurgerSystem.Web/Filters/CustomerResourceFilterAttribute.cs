using BurgerSystem.Ability.Docking.StoreApp.Dto;
using BurgerSystem.Domain.StoreInfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace BurgerSystem.Web.Filters
{
    public class CustomerResourceFilterAttribute : Attribute, IResourceFilter
    {
        // dependency injection
        public CustomerResourceFilterAttribute(IMemoryCache memoryCache)
        {
            MemoryCache = memoryCache;
        }

        public IMemoryCache MemoryCache { get; }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var path = context.HttpContext.Request.Path;   // path of the store is unique
            var result = context.Result as ObjectResult;
            var storeDto = result.Value as StoreDto;
            if(storeDto != null)
            {
                // if scores of this store are more than 4, save it to cache
                if(storeDto.TasteScoreAverage > 4 && storeDto.TextureScoreAverage > 4 && storeDto.VisualScoreAverage > 4)
                {
                    MemoryCache.Set(path, context.Result);
                }
            }
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var path = context.HttpContext?.Request.Path;
            if (MemoryCache.TryGetValue(path, out object value))
            {
                context.Result = value as ObjectResult;
            }
        }
    }
}
