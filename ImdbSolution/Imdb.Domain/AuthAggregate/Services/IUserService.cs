using Imdb.Domain.AuthAggregate.Dtos;
using Imdb.Domain.Shared.Filters;

namespace Imdb.Domain.AuthAggregate.Services
{
    public interface IUserService
    {
        void RegisterAdmin(AdminForRegisterDto adminForRegisterDto);
        void RegisterUser(UserForRegisterDto userForRegisterDto);
        void UpdateUser(UserForUpdateDto userForUpdateDto);
        void InactivateUserAsAdmin(int idUser);
        void InactivateUser();
        GenericFilter<UsersForList> GetUsers(GenericFilter<UsersForList> filter);
    }
}
