using R5DNCloud.Infrastructure.Options;
using Snowflake.Core;

namespace R5DNCloud.Infrastructure;

/// <summary>
/// 分布式雪花Id生成器
/// </summary>
public class SnowFlake
{
    private static readonly Lazy<IdWorker> _instance = new(() =>
    {
        var commonOptions = App.Options<CommonOptions>();

        return new IdWorker(commonOptions.WorkerId, commonOptions.DatacenterId);
    });

    public static IdWorker Instance = _instance.Value;
}