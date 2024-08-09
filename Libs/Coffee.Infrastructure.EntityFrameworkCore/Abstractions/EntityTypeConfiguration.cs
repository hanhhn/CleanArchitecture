using System.Reflection;
using Coffee.Infrastructure.EntityFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coffee.Infrastructure.EntityFrameworkCore.Abstractions
{
    public abstract class EntityTypeConfiguration<TEntity> : IMappingConfiguration, IEntityTypeConfiguration<TEntity> where TEntity : class
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            PropertyInfo prop = typeof(TEntity).GetProperty("Id");
            if (prop != null)
            {
                builder.HasKey("Id");

                if (prop.PropertyType.ToString() == typeof(int).ToString())
                {
                    builder.Property("Id")
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .ValueGeneratedOnAdd();
                }
            }
        }

        public virtual void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}

