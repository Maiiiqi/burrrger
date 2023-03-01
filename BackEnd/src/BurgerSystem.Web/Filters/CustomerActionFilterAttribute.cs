using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace BurgerSystem.Web.Filters
{
    public class CustomerActionFilterAttribute : Attribute, IActionFilter
    {
        // dependency injection for cache
        public CustomerActionFilterAttribute(IMemoryCache memoryCache)
        {
            MemoryCache = memoryCache;
        }

        public IMemoryCache MemoryCache { get; }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // check if token is carried from request from front end
            if(context.ActionArguments.ContainsKey("token"))
            {
                // get token from cache
                var token = context.ActionArguments["token"].ToString();
                var hasToken = MemoryCache.TryGetValue(token, out object value);
                if (hasToken)
                {
                    context.HttpContext.Items.Add("loginSuccessInfo", value);
                    // reset token to implement a sliding window of expired time
                    // 5 min
                    MemoryCache.Set(token, value, TimeSpan.FromMinutes(5));
                }
                else
                {
                    // no token in cache, short circuit
                    context.Result = new JsonResult(null) { StatusCode = 203 };   // not login, no authorization
                }
            }
        }
    }
}
