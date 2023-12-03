using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PL.Controllers
{
    public class CategorysController : ApiController
    {
        [Route("api/getCategoryTest")]
        public HttpResponseMessage GetTest()
        {
            var name = "Category Controller";
            //var name = new string[] { "Tuhin", "Reza" };
            return Request.CreateResponse(HttpStatusCode.OK, name);
        }

    }
}
