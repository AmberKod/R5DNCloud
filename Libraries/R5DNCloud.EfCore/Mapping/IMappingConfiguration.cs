using Microsoft.EntityFrameworkCore;
using R5DNCloud.EfCore.Entities;

namespace R5DNCloud.EfCore.Mapping;

public interface IMappingConfiguration
{
    void ApplyConfiguration(ModelBuilder modelBuilder);
}

public interface IMappingConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>, IMappingConfiguration where TEntity : class, IEntity
{

}