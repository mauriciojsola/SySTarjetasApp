namespace SySTarjetas.Core.Infrastructure.Persistence
{
    public class ThreadStaticObjectContextProvider : IObjectContextProvider
    {
        private ObjectContext _currentObjectContext;

        public IObjectContextFactory ObjectContextFactory { private get; set; }

        public bool HasCurrent
        {
            get { return _currentObjectContext != null; }
        }

        public ObjectContext Current
        {
            get { return (_currentObjectContext = _currentObjectContext ?? ObjectContextFactory.CreateObjectContext()); }
        }

        public void Clear()
        {
            _currentObjectContext = null;
        }
    }
}
