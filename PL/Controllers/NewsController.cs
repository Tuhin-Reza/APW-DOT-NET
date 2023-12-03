using BLL.Services;
using System;
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

        [HttpGet]
        [Route("api/getNews/{id}")]
        public HttpResponseMessage getNews(int id)
        {
            try
            {
                var data = NewsService.getNews(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
