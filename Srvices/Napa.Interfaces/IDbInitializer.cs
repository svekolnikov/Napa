namespace Napa.Interfaces
{
    public interface IDbInitializer
    {
        Task Initialize(CancellationToken cancel = default);
    }
}
