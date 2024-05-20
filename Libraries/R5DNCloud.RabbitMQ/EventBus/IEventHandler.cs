namespace R5DNCloud.RabbitMQ.EventBus
{
    public interface IEventHandler
    {

    }

    public interface IEventHandler<TEvent> : IEventHandler
    {
        Task HandleAsync(TEvent @event);
    }
}
