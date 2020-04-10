using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Tasky2.Controllers;

namespace Tasky2.ServiceFilter
{
    public class ClaimServiceFilter : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
             var  userId = context.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(s => s.Value).FirstOrDefault();

             ((TaskApiBaseController) context.Controller).UserId = Convert.ToInt32(userId);
            
            return base.OnActionExecutionAsync(context, next);
        }

        
    }
}
