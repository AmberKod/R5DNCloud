namespace R5DNCloud.RabbitMQ.EventBus
{
    /// <summary>
    /// 事件传输实体的基础接口
    /// </summary>
    public interface IEvent
    {
        object Id { get; set; }
    }
}
