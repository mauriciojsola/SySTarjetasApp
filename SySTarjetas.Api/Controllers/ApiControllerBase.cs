using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SySTarjetas.Api.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected HttpResponseMessage BadRequestResponse(string message)
        {
            return GenericRequestResponse(HttpStatusCode.BadRequest, message);
        }

        protected HttpResponseMessage ForbiddenResourceResponse(string message)
        {
            return GenericRequestResponse(HttpStatusCode.Forbidden, message);
        }

        protected HttpResponseMessage StatusOkResponse(string message)
        {
            return GenericRequestResponse(HttpStatusCode.OK, message);
        }

        protected HttpResponseMessage GenericRequestResponse(string message)
        {
            return GenericRequestResponse(HttpStatusCode.OK, message);
        }

        protected HttpResponseMessage GenericRequestResponse(HttpStatusCode httpStatusCode, string message)
        {
            return Request.CreateResponse(httpStatusCode, message);
        }
    }
}