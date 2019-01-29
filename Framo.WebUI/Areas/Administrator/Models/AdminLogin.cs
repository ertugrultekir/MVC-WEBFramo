using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Framo.WebUI.Areas.Administrator.Models
{
    public class AdminLogin : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["oturum"] != null)
            {
                return true;
            }
            else
            {
                httpContext.Response.Redirect("/Administrator/User/Login");
                return false;
            }
        }
    }
}