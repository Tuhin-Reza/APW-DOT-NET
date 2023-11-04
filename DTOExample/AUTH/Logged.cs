﻿using System.Web;
using System.Web.Mvc;

namespace DTOExample.AUTH
{
    public class Logged : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["user"] != null)
            {
                return true;
            }

            return false;
        }
    }
}