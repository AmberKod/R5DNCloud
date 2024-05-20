using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace R5DNCloud.Serilog;

/// <summary>
/// 在日志中记录请求的 IP 地址
/// ILogEventEnricher接口可以增加额外的信息在日志中，通过实现Enrich
/// </summary>
public class IpAddressEnricher(IHttpContextAccessor httpContextAccessor) : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var httpContext = httpContextAccessor.HttpContext;
        if (httpContext is null)
        {
            return;
        }

        var ipAddress = httpContext.Request.GetRemoteIpAddress();
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("IpAddress", ipAddress, true));
    }
}