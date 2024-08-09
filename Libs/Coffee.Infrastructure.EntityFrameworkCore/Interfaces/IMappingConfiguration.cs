using Microsoft.EntityFrameworkCore;

namespace Coffee.Infrastructure.EntityFrameworkCore.Interfaces
{
    public partial interface IMappingConfiguration
    {
        void ApplyConfiguration(ModelBuilder modelBuilder);
    }
}

