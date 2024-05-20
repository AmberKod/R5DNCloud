using R5DNCloud.Infrastructure;

namespace R5DNCloud.EfCore.Entities;

/// <summary>
/// 拥有IsDelete软删除标识，CreatedAt CreateBy、UpdatedAt UpdateBy 默认主键为long类型
/// </summary>
public abstract class AuditedEntity : AuditedEntity<long>
{
    public AuditedEntity() : base(SnowFlake.Instance.NextId())
    {
    }
}

/// <summary>
/// 拥有IsDelete软删除标识，CreatedAt CreateBy、UpdatedAt UpdateBy 主键可传递类型
/// </summary>
/// <typeparam name="TKey"></typeparam>
public abstract class AuditedEntity<TKey> : EntityBase<TKey>, IAuditedEntity
{
    protected AuditedEntity(TKey id)
        : base(id)
    {
    }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    /// <summary>
    /// 创建人id
    /// </summary>
    public long? CreatedBy { get; set; } = 0;

    /// <summary>
    /// 修改时间
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    /// <summary>
    /// 修改人id
    /// </summary>
    public long? UpdatedBy { get; set; } = 0;

    /// <summary>
    /// 备注
    /// </summary>
    public string Remark { get; set; } = string.Empty;
}