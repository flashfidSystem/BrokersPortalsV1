using BrokersPortalsV1.Class;
using BrokersPortalsV1.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BrokersPortalsV1.Security.Filter
{
    public class CustomAuthorisationFilter : Attribute, IAuthorizationFilter
    {
        //private readonly IUserPermission _userPermission;
        //public CustomAuthorisationFilter(IUserPermission userPermission)
        //{
        //    _userPermission = userPermission;
        //}

        private readonly UserActionType actionFunctions; 
        private readonly FormsModule moduleFunction;
        private readonly FormsSubModule subModuleFunction;

        public CustomAuthorisationFilter(FormsSubModule subModuleFunction, UserActionType actionFunctions)
        {
            
        }

        public CustomAuthorisationFilter(FormsModule moduleFunction)
        {
            this.moduleFunction = moduleFunction; 
        }



        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //_userPermission.HasPermission();
            //context.HttpContext.Response.Redirect("/Home/Unauthorised"); 
        }
    }
}
