namespace Imdb.Domain.Shared.Interfaces
{
    public interface IUnityOfWork
    {
        bool Commit();
    }
}
