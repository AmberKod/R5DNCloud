using R5DNCloud.Infrastructure;
using Serilog.Core;
using Serilog.Events;

namespace R5DNCloud.Serilog;

/// <summary>
/// 将TokenId写入日志
/// ILogEventEnricher接口可以增加额外的信息在日志中，通过实现Enrich
/// </summary>
public class TokenEnricher : ILogEventEnricher
{
    private readonly ICurrentUser currentUser;

    public TokenEnricher(ICurrentUser currentUser)
    {
        this.currentUser = currentUser;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        if(this.currentUser is null || !this.currentUser.IsAuthenticated)
        {
            return;
        }
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("TokenId", this.currentUser.TokenId, true));
    }
}