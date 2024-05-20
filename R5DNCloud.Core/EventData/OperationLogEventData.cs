using R5DNCloud.RabbitMQ.EventBus;

namespace R5DNCloud.Core.EventData
{
    /// <summary>
    /// 操作日志事件传输数据
    /// </summary>
    public class OperationLogEventData: EventBase
    {
        /// <summary>
        /// 菜单Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 操作内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 传递参数
        /// </summary>
        public string Json { get; set; }

        /// <summary>
        /// ip地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserAgent { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 获取该请求方法
        /// </summary>
        public string Method { get; set; }
    }
}
