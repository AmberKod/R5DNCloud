namespace R5DNCloud.RabbitMQ.EventBus
{
    /// <summary>
    /// 事件传递数据基类
    /// </summary>
    public class EventBase : IEvent
    {
        public object Id { get; set; } = Guid.NewGuid();

        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
