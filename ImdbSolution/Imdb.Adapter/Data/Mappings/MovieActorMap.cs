using Imdb.Domain.MovieAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Imdb.Adapter.Data.Mappings
{
    public class MovieActorMap : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.IdActor).IsRequired();

            builder.Property(x => x.IdMovie).IsRequired();
        }
    }
}
