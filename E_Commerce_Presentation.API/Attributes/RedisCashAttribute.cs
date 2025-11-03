using E_Commerce_service_Abstraction.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Presentation.API.Attributes
{
    public class RedisCashAttribute(int DurationInmin=2) : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cashService = context.HttpContext.RequestServices.GetRequiredService<ICashService>();

            string key = GenerateCashKey(context.HttpContext.Request);


            var cashvalue= await cashService.GetAsync(key);

            if(cashvalue != null)
            {
                context.Result = new ContentResult
                {
                    Content = cashvalue,
                    ContentType = "application/json",
                    StatusCode = StatusCodes.Status200OK
                };
                return;
            }

            var actionExecutedContext = await next.Invoke();

            var result = actionExecutedContext.Result;

            if(result is OkObjectResult okResult)
            {
                await cashService.SetAsync(key,okResult.Value!, TimeSpan.FromMinutes(DurationInmin));
            }

        }
        private static string GenerateCashKey(HttpRequest request)
        {
            var sb = new StringBuilder();

            foreach (var item in request.Query.OrderBy(q => q.Key))
            {
                sb.Append($"{item.Key}-{item.Value}");
            }

            return sb.ToString().Trim('-');
        }


    }

}


 
