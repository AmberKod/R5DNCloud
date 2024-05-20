namespace R5DNCloud.RabbitMQ.EventBus
{
    /// <summary>
    /// RabbitMQ 发布接口
    /// </summary>
    public interface IEventPublisher
    {
        /// <summary>
        /// 暂时没定义RabbitMQ 消息的类型
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="message"></param>
        Task Publish<TEvent>(TEvent message) where TEvent : IEvent;
    }
}
