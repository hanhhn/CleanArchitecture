using Coffee.Infrastructure.EntityFrameworkCore.PostgreSQL;
using Domain.Entities.PostAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations
{
    public class PostEntityConfiguration : PostgreEntityTypeConfiguration<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Post));

            builder.Property(x => x.Title)
                .HasColumnName("title")
                .HasColumnType("varchar(200)");

            builder.Property(x => x.Image)
                .HasColumnName("image")
                .HasColumnType("varchar(500)");

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("text");

            builder.Property(x => x.Content)
                .HasColumnName("content");

            builder.HasMany(x => x.Comments)
                .WithOne(y => y.Post)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

