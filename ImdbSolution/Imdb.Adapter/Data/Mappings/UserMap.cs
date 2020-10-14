using Imdb.Domain.AuthAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Imdb.Adapter.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();

            builder.Property(x => x.UserName).HasMaxLength(50).IsRequired();

            builder.Property(x => x.PasswordHash).IsRequired();

            builder.Property(x => x.Admin).IsRequired();
        }
    }
}
