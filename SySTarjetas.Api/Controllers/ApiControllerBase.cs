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

        protected HttpResponseMessage BadRequestResponse(object content)
        {
            return GenericRequestResponse(HttpStatusCode.BadRequest, content);
        }

        protected HttpResponseMessage ForbiddenResourceResponse(string message)
        {
            return GenericRequestResponse(HttpStatusCode.Forbidden, message);
        }

        protected HttpResponseMessage SuccessResponse(string message)
        {
            return GenericRequestResponse(HttpStatusCode.OK, message);
        }

        protected HttpResponseMessage SuccessResponse(object content)
        {
            return GenericRequestResponse(HttpStatusCode.OK, content);
        }

        protected HttpResponseMessage GenericRequestResponse(string message)
        {
            return GenericRequestResponse(HttpStatusCode.OK, message);
        }

        protected HttpResponseMessage GenericRequestResponse(object content)
        {
            return GenericRequestResponse(HttpStatusCode.OK, content);
        }

        protected HttpResponseMessage GenericRequestResponse(HttpStatusCode httpStatusCode, object message)
        {
            return Request.CreateResponse(httpStatusCode, message);
        }
    }
}