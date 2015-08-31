namespace SySTarjetas.Core.Infrastructure.Persistence
{
    public class ThreadStaticUnitOfWorkProvider : IUnitOfWorkProvider
    {
        public IObjectContextProvider ObjectContextProvider { private get; set; }

        public IUnitOfWork BeginUnitOfWork()
        {
            ObjectContextProvider.Clear();
            return Current = new UnitOfWork(ObjectContextProvider);
        }

        public IUnitOfWork Current { get; private set; }
    }

    public interface IUnitOfWorkProvider
    {
        IUnitOfWork BeginUnitOfWork();
        IUnitOfWork Current { get; }
    }
}
