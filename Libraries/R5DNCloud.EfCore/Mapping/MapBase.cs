using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using R5DNCloud.EfCore.Entities;

namespace R5DNCloud.EfCore.Mapping;

public abstract class MapBase<TEntity, TKey> : IMappingConfiguration<TEntity> where TEntity : Entity<TKey> where TKey : struct
{
    public void ApplyConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(this);
    }

    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
    }
}

/// <summary>
/// EFCore 实体映射到数据库表结构的基类
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public abstract class MapBase<TEntity> : MapBase<TEntity, long> where TEntity : Entity<long>
{
    
}