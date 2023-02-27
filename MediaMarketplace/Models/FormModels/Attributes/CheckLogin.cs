using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MediaMarketplace.Services.System;

namespace MediaMarketplace.Models.FormModels.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CheckLogin : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        { 
            if (filterContext == null)
                return;

            var userService = new UserSessionService();
            if (userService.IsLoggedIn())
                return;

            filterContext.Result = new RedirectResult("/Home");
        }
    }
}