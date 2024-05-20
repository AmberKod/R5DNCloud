using R5DNCloud.Infrastructure;
using R5DNCloud.Infrastructure.Options;
using Serilog.Core;
using Serilog.Events;

namespace R5DNCloud.Serilog;

/// <summary>
/// 将配置文件中的WorkId写入日志
/// ILogEventEnricher接口可以增加额外的信息在日志中，通过实现Enrich
/// </summary>
public class WorkerEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var options = App.Options<CommonOptions>();
        // 获取每个微服务配置文件中配置的 WorkerId 和 DataCenterId
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("WorkerId", options.WorkerId, true));
    }
}