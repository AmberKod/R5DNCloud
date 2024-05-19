using R5DNCloud.Infrastructure.Enums;

namespace R5DNCloud.Infrastructure.Options;

/// <summary>
/// 配置文件中的存储配置
/// </summary>
public class StorageOptions : IOptions
{
    /// <summary>
    /// 节点名称
    /// </summary>
    public string SectionName => "Storage";
    
    /// <summary>
    /// 本地存储保存路径
    /// </summary>
    public string Path { get; set; }
    
    /// <summary>
    /// 临时文件保存路径
    /// </summary>
    public string TempPath { get; set; }

    public FileStorageType Type { get; set; } = FileStorageType.Local;
}