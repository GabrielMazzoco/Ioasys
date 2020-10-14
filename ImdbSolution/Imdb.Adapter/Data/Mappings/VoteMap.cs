using Imdb.Domain.MovieAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Imdb.Adapter.Data.Mappings
{
    public class VoteMap : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.IdUser).IsRequired();

            builder.Property(x => x.IdMovie).IsRequired();

            builder.HasOne(x => x.Movie)
                .WithMany(x => x.Votes)
                .HasForeignKey(x => x.IdMovie);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Votes)
                .HasForeignKey(x => x.IdUser);
        }
    }
}
