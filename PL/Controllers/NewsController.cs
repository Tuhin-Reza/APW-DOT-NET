using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PL.Controllers
{
    public class NewsController : ApiController
    {
        [Route("api/getNewsTest")]
        public HttpResponseMessage GetTest()
        {
            var name = "News Controller";
            //var name = new string[] { "Tuhin", "Reza" };
            return Request.CreateResponse(HttpStatusCode.OK, name);
        }

    }
}
