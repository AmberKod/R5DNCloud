using R5DNCloud.Infrastructure;

namespace R5DNCloud.EfCore.Entities;

/// <summary>
/// 抽象化接口实体基础类（只有主键）
/// </summary>
/// <typeparam name="TKey"></typeparam>
public abstract class Entity<TKey> : IEntity<TKey>
{
    protected Entity()
    {
        
    }

    protected Entity(TKey id)
    {
        this.Id = id;
    }
    
    /// <summary>
    /// Id 主键
    /// </summary>
    public virtual TKey Id { get; set; }
}

/// <summary>
/// 抽象化接口实体基础类（可用于默认初始化 相当于只有主键Key）
/// </summary>
public abstract class Entity : Entity<long>
{
    public Entity() : base(SnowFlake.Instance.NextId())
    {}
}