using System.Web;
using System.Web.Mvc;

namespace Task3.AUTH
{
    public class Logged : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["userData"] != null)
            {
                return true;
            }

            return false;
        }
    }
}