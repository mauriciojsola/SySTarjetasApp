using System.Collections.Generic;
using System.Linq;

namespace SySTarjetas.Api.Common
{
    public class JsonResponse
    {
        public JsonResponse() : this(string.Empty)
        {
        }

        public JsonResponse(string message) : this(message, new List<string>())
        {
        }

        public JsonResponse(string message, IList<string> errors)
        {
            Errors = errors;
            Message = message;
        }

        public bool Success { get { return !HasErrors; } }
        public bool HasErrors { get { return Errors.Any(); } }
        public IList<string> Errors { get; set; }
        public string Message { get; set; }
    }
}