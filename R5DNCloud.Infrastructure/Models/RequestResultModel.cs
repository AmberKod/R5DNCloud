namespace R5DNCloud.Infrastructure.Models;

/// <summary>
/// 请求结果返回实体
/// </summary>
[Serializable]
public class RequestResultModel
{
    public RequestResultModel()
    {

    }

    public RequestResultModel(int code, string message, object data)
    {
        Code = code;
        Message = message;
        Data = data;
    }

    /// <summary>
    /// 状态码
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// 消息
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// 返回数据
    /// </summary>
    public Object Data { get; set; }

    /// <summary>
    /// 时间戳
    /// </summary>
    public long Timestamp { get; set; } = DateTimeOffset.Now.ToUnixTimeMilliseconds();
}

/// <summary>
/// 请求结果分页返回实体
/// </summary>

public class  RequestPagedResultModel: RequestResultModel
{
    /// <summary>
    /// 总数量
    /// </summary>
    public int Total { get; set; }

    /// <summary>
    /// 当前页
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// 总页数
    /// </summary>
    public int TotalPage { get; set; }

    /// <summary>
    /// 分页大小
    /// </summary>
    public int Limit { get; set; }
}