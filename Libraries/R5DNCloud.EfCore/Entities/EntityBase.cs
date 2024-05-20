using R5DNCloud.Infrastructure;

namespace R5DNCloud.EfCore.Entities;

/// <summary>
/// 抽象化数据实体基类，添加了软删除的功能
/// </summary>
/// <typeparam name="TKey"></typeparam>
public abstract class EntityBase<TKey> : Entity<TKey>, ISoftDelete
{
    protected EntityBase(TKey id)
    {
        Id = id;
    }

    /// <summary>
    /// 是否删除
    /// </summary>
    public bool IsDeleted { get; set; } = false;
}

/// <summary>
/// 抽象化数据默认实体基类，设置主键以及软删除
/// </summary>
public abstract class EntityBase : EntityBase<long>
{
    public EntityBase() : base(SnowFlake.Instance.NextId())
    {
        
    }
}