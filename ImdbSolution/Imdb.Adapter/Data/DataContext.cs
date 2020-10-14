using Imdb.Adapter.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Imdb.Adapter.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new MovieMap());
            modelBuilder.ApplyConfiguration(new ActorMap());
            modelBuilder.ApplyConfiguration(new MovieActorMap());
        }
    }
}
