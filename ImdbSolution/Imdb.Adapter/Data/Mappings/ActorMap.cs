using Imdb.Domain.MovieAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Imdb.Adapter.Data.Mappings
{
    public class ActorMap : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x => x.Movies)
                .WithOne(x => x.Actor)
                .HasForeignKey(x => x.IdActor);
        }
    }
}
