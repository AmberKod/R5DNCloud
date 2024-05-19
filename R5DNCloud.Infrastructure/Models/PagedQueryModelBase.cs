namespace R5DNCloud.Infrastructure.Models;

/// <summary>
/// 接口分页参数基类，可以直接使用，以及参数不够可被继承
/// </summary>
public class PagedQueryModelBase
{
    /// <summary>
    /// 分页大小
    /// </summary>
    public int Limit { get; set; } = 15;

    /// <summary>
    /// 页码
    /// </summary>
    public int Page { get; set; } = 1;
    
    /// <summary>
    /// 搜索关键字
    /// </summary>
    public string Keyword { get; set; }
}