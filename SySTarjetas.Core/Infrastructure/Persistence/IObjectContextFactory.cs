namespace SySTarjetas.Core.Infrastructure.Persistence
{
    public interface IObjectContextFactory
    {
        ObjectContext CreateObjectContext();
    }
}