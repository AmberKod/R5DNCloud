using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using R5DNCloud.EfCore.Entities;

namespace R5DNCloud.Core.Domains;

/// <summary>
/// 操作日志
/// </summary>
public class OperationLog : AuditedEntity
{
    /// <summary>
    /// IP 地址
    /// </summary>
    [MaxLength(128)]
    public string IpAddress { get; set; }

    /// <summary>
    /// User Agent
    /// </summary>
    [MaxLength(512)]
    public string UserAgent { get; set; }

    /// <summary>
    /// 操作
    /// </summary>
    [MaxLength(512)]
    public string OperationContent { get; set; }

    /// <summary>
    /// 菜单代码
    /// </summary>
    [MaxLength(128)]
    public string MenuCode { get; set; }

    /// <summary>
    /// 操作菜单
    /// </summary>
    public string OperationMenu { get; set; }

    /// <summary>
    /// 创建人
    /// </summary>
    [ForeignKey(nameof(CreatedBy))]
    public virtual User CreatedUser { get; set; }
}