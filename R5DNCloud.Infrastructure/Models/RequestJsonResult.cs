using Microsoft.AspNetCore.Mvc;

namespace R5DNCloud.Infrastructure.Models;

/// <summary>
/// 继承JsonResult，用于统一返回数据格式
/// </summary>
public class RequestJsonResult : JsonResult
{
    public RequestJsonResult(object value) : base(value)
    {
    }
}