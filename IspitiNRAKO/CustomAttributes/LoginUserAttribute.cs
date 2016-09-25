using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace IspitiNRAKO.CustomAttributes
{
    public class LoginUserAttribute : FilterAttribute, IAuthenticationFilter
    {

        string superAdminRole = "SuperAdmin";
        string adminRole = "Admin";
        string userRole = "User";

        public void OnAuthentication(AuthenticationContext filterContext)
        {

            if (filterContext.HttpContext.Session["UserType"] == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }

            else if (filterContext.HttpContext.Session["UserType"].ToString().Equals(superAdminRole) )
            {

            }
            else
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult("Default",
                    new System.Web.Routing.RouteValueDictionary{
                        {"controller", "Login"},
                        {"action", "Login"},
                        {"returnUrl", filterContext.HttpContext.Request.RawUrl}
                    });

            }
        }

        
    }
}