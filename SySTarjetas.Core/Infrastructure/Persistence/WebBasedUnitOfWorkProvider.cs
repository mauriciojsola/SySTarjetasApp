using System.Web;

namespace SySTarjetas.Core.Infrastructure.Persistence
{
    public class WebBasedUnitOfWorkProvider : IUnitOfWorkProvider
    {
        private const string HttpContextKey = "EF.Uow.Key";

        public IObjectContextProvider ObjectContextProvider { private get; set; }

        public IUnitOfWork BeginUnitOfWork()
        {
            ObjectContextProvider.Clear();
            HttpContext.Current.Items[HttpContextKey] = new UnitOfWork(ObjectContextProvider);
            return Current;
        }

        public IUnitOfWork Current
        {
            get { return HttpContext.Current.Items[HttpContextKey] as UnitOfWork; }
        }
    }
}
