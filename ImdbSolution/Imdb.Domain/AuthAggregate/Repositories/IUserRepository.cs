using Imdb.Domain.AuthAggregate.Dtos;
using Imdb.Domain.AuthAggregate.Entities;
using Imdb.Domain.Shared.Filters;
using Imdb.Domain.Shared.Interfaces;

namespace Imdb.Domain.AuthAggregate.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string userName);
        GenericFilter<UsersForList> GetUsers(GenericFilter<UsersForList> filter);
    }
}
