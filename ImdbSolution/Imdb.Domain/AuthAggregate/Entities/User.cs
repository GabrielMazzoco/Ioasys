using Imdb.Domain.Shared.Entities;

namespace Imdb.Domain.AuthAggregate.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public bool Admin { get; set; }
    }
}
