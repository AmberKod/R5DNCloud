using R5DNCloud.EfCore.Entities;
using R5DNCloud.EfCore.Repository.AutoMapper;

namespace R5DNCloud.EfCore.Repository;

public interface IServiceBase<TEntity> : IServiceBase<TEntity, long> where TEntity : class, IEntity<long>
{
    
}

public interface IServiceBase<TEntity, TKey> : IAutoMapperRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
{
}