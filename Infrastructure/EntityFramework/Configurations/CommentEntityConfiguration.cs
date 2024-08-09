using Coffee.Infrastructure.EntityFrameworkCore.PostgreSQL;
using Domain.Entities.PostAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations
{
    public class CommentEntityConfiguration : PostgreEntityTypeConfiguration<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Comment));

            builder.Property(x => x.Owner)
                .HasColumnName("owner")
                .HasColumnType("varchar(36)");

            builder.Property(x => x.Message)
                .HasColumnName("message")
                .HasColumnType("text");
        }
    }
}

