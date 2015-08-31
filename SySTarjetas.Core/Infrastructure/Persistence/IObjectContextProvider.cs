namespace SySTarjetas.Core.Infrastructure.Persistence
{
    public interface IObjectContextProvider
    {
        bool HasCurrent { get; }
        ObjectContext Current { get; }
        void Clear();
    }
}