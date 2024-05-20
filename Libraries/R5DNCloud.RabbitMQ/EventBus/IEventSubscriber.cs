namespace R5DNCloud.RabbitMQ.EventBus
{
    /// <summary>
    /// RabbitMQ订阅者接口
    /// </summary>
    public interface IEventSubscriber: IDisposable
    {
        Task Subscribe(Type eventType, Type eventHandlerType);
    }
}
