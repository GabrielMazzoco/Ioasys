using Imdb.Domain.AuthAggregate.Dtos;

namespace Imdb.Domain.AuthAggregate.Services
{
    public interface IAuthService
    {
        string Login(LoginDto loginDto);
        string GeneratePasswordHash(string password);
    }
}
