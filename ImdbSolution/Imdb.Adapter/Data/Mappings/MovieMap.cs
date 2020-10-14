using Imdb.Domain.MovieAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Imdb.Adapter.Data.Mappings
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Director).IsRequired();

            builder.Property(x => x.Genre).IsRequired();

            builder.Property(x => x.Rating).HasDefaultValue(0).IsRequired();

            builder.HasMany(x => x.Actors)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.IdMovie);
        }
    }
}
