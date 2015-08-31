using System.Web;

namespace SySTarjetas.Core.Infrastructure.Persistence
{
    public class WebBasedObjectContextProvider : IObjectContextProvider
    {
        private const string Httpcontextkey = "EF.ObjectContext.Key";

        public IObjectContextFactory ObjectContextFactory { private get; set; }

        public bool HasCurrent
        {
            get { return (HttpContext.Current.Items[Httpcontextkey] as ObjectContext) != null; }
        }

        public ObjectContext Current
        {
            get
            {
                var context = HttpContext.Current.Items[Httpcontextkey] as ObjectContext;
                if (context == null)
                {
                    HttpContext.Current.Items[Httpcontextkey] =
                        context = ObjectContextFactory.CreateObjectContext();
                }

                return context;
            }
        }

        public void Clear()
        {
            HttpContext.Current.Items[Httpcontextkey] = null;
        }
    }
}
