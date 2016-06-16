using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Autofac.Integration.WebApi;
using SySTarjetas.Core.Infrastructure.Persistence;

namespace SySTarjetas.Api.Filters
{
    public class UnitOfWorkFilter : IAutofacActionFilter
    {
        public IUnitOfWorkProvider UnitOfWorkProvider { private get; set; }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            UnitOfWorkProvider.BeginUnitOfWork();
        }

        public void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null) return;
            UnitOfWorkProvider.Current.Commit();
        }
        
    }
}