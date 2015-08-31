using System;

namespace SySTarjetas.Core.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IObjectContextProvider _objectContextProvider;

        public UnitOfWork(IObjectContextProvider objectContextProvider)
        {
            _objectContextProvider = objectContextProvider;
        }

        public void Commit()
        {
            if (!_objectContextProvider.HasCurrent) return;

            _objectContextProvider.Current.SaveChanges();

            if (OnSuccess != null)
                OnSuccess(this, new EventArgs());
        }

        public void Rollback()
        {
            if (!_objectContextProvider.HasCurrent) return;

            if (OnFail != null)
                OnFail(this, new EventArgs());
        }

        public event EventHandler OnSuccess;
        public event EventHandler OnFail;

        public void Dispose()
        {
            if (_objectContextProvider.HasCurrent)
            {
                _objectContextProvider.Current.Dispose();
                _objectContextProvider.Clear();
            }
                
        }
    }

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
        event EventHandler OnSuccess;
        event EventHandler OnFail;
    }
}
