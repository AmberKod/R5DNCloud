namespace R5DNCloud.EfCore.Entities;

/// <summary>
/// 给数据表实体添加软删除标记
/// </summary>
public interface ISoftDelete
{
    /// <summary>
    /// 是否删除
    /// </summary>
    bool IsDeleted { get; set; }
}