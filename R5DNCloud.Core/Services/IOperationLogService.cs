using R5DNCloud.Core.Domains;
using R5DNCloud.EfCore.Repository;

namespace R5DNCloud.Core.Services;

/// <summary>
/// 操作日志服务接口
/// </summary>
public interface IOperationLogService : IServiceBase<OperationLog>
{
    /// <summary>
    /// 记录操作日志
    /// </summary>
    /// <param name="code">菜单Code</param>
    /// <param name="content">操作内容</param>
    /// <param name="remark">操作参数</param>
    /// <param name="ipAddress"></param>
    /// <param name="userAgent"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task LogAsync(string code, string content, string remark, string ipAddress, string userAgent,long userId = 0);
}