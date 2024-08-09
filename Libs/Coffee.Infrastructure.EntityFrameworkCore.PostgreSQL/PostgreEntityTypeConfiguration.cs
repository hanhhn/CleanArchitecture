using System.Reflection;
using Coffee.Infrastructure.EntityFrameworkCore.Abstractions;
using Coffee.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coffee.Infrastructure.EntityFrameworkCore.PostgreSQL
{
    public class PostgreEntityTypeConfiguration<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            PropertyInfo prop = typeof(TEntity).GetProperty("Id");
            if (prop != null)
            {
                builder.HasKey("Id");

                if (prop.PropertyType.ToString() == typeof(int).ToString()
                    || prop.PropertyType.ToString() == typeof(long).ToString())
                {
                    builder.Property("Id")
                        .HasColumnName("id")
                        .HasColumnType("long")
                        .ValueGeneratedOnAdd();
                }
                else
                {
                    builder.Property("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(36)");
                }
            }

            prop = typeof(TEntity).GetProperty(nameof(IAuditableEntity.CreatedAt));
            if (prop != null)
            {
                builder.Property(nameof(IAuditableEntity.CreatedAt))
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");
            }

            prop = typeof(TEntity).GetProperty(nameof(IAuditableEntity.CreatedBy));
            if (prop != null)
            {
                builder.Property(nameof(IAuditableEntity.CreatedBy))
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50);
            }

            prop = typeof(TEntity).GetProperty(nameof(IAuditableEntity.UpdatedAt));
            if (prop != null)
            {
                builder.Property(nameof(IAuditableEntity.UpdatedAt))
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            }

            prop = typeof(TEntity).GetProperty(nameof(IAuditableEntity.UpdatedBy));
            if (prop != null)
            {
                builder.Property(nameof(IAuditableEntity.UpdatedBy))
                    .HasColumnName("updated_by")
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50);
            }

            prop = typeof(TEntity).GetProperty(nameof(IDeleteEntity.IsDeleted));
            if (prop != null)
            {
                builder.Property(nameof(IDeleteEntity.IsDeleted))
                    .HasColumnName("is_deleted")
                    .HasDefaultValue(false);
            }

            prop = typeof(TEntity).GetProperty(nameof(IAuditableEntity.Version));
            if (prop != null)
            {
                builder.Property(nameof(IAuditableEntity.Version))
                    .HasColumnName("version")
                    .IsConcurrencyToken();
            }
        }
    }
}

