using Orchard.Net.Dev.Test.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace Orchard.Net.Dev.Test.Controllers.API
{
    [RoutePrefix("api/post")]
    public class PostController : ApiController
    {
        // GET: api/Post
        public IHttpActionResult Get()
        {
            //return Content(System.Net.HttpStatusCode.BadRequest, "Method Not Allowed");
            throw new ApplicationException("Method not Allowed");
        }

        // GET: api/Post/5
        public string Get(int id)
        {
            throw new ApplicationException("Method not Allowed");
        }

        // POST: api/Post
        [RequireAPIToken]
        public HttpResponseMessage Post([FromBody] Post post)
        {
            if (post == null) new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);

            // POST to 3rd party API
            return new HttpResponseMessage(Helper.RESTApi.HttpPost(post));
        }

        // PUT: api/Post/5
        public void Put(int id, [FromBody]string value)
        {
            throw new ApplicationException("Method not Allowed");
        }

        // DELETE: api/Post/5
        public void Delete(int id)
        {
            throw new ApplicationException("Method not Allowed");
        }
    }
}
