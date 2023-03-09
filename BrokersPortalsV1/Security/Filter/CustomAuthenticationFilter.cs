using BrokersPortalsV1.Class;
using BrokersPortalsV1.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BrokersPortalsV1.Security.Filter
{
    public class CustomAuthenticationFilter : IActionFilter
    {
        private readonly ISessionHandler _SessionHandler;
        public CustomAuthenticationFilter(ISessionHandler sessionHandler)
        {
            _SessionHandler = sessionHandler;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Root UserDetails = _SessionHandler.getSession<Root>(SessionVariable.LOGGEDUSER);
            //if (UserDetails == null)
            //{
            //    context.HttpContext.Response.Redirect("/Account/Login");
            //}

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Root UserDetails = _SessionHandler.getSession<Root>(SessionVariable.LOGGEDUSER); 
            //if (UserDetails == null)
            //{
            //    //context.Result = new UnauthorizedResult();
            //    context.HttpContext.Response.Redirect("/Account/Login");
            //}

            //if (!context.ModelState.IsValid)
            //{
            //    context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            //} 
        }
    }
}
