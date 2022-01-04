using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace my.doctor.web.Configurations.Login
{
    public class UserLoginAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var loginUser = (LoginUser)context.HttpContext.RequestServices.GetService(typeof(LoginUser));
            var user = loginUser.GetUser();

            if (user == null)
            {
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
        }
    }
}
