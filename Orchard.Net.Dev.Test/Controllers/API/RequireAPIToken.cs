using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Orchard.Net.Dev.Test.Helper;

namespace Orchard.Net.Dev.Test.Controllers.API
{
    public class RequireAPIToken : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var id = 0;
            //https://stackoverflow.com/questions/18985393/how-to-safely-access-actioncontext-request-headers-getvalues-if-the-key-is-not-f
            IEnumerable<string> values;
            var apiKey = actionContext.Request.Headers.TryGetValues(APIKey.AuthKey, out values) ? values.First() : string.Empty;
            if (!APIKey.Authenticate(apiKey, out id))
            {
                throw new System.Web.Http.HttpResponseException(new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized));
            }
        }
    }
}