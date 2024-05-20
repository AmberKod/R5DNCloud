using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using R5DNCloud.RabbitMQ.EventBus;
using RabbitMQ.Client;

namespace R5DNCloud.RabbitMQ;
public class EventPublisher : IEventPublisher
{
    private readonly IConnection connection;
    private readonly ILogger<EventPublisher> logger;
    private readonly RabbitOptions options;
    
    private IChannel publisherChannel;
    public EventPublisher(IConnection connection, ILogger<EventPublisher> logger, IOptions<RabbitOptions> options) 
    {
        this.connection = connection;
        this.logger = logger;
        this.options = options.Value;
        this.publisherChannel = CreateChannel().Result;
    }

    public async Task Publish<TEvent>(TEvent message) where TEvent : IEvent
    {
        var eventName = message.GetType().FullName;
        var body = JsonSerializer.Serialize(message);

        await publisherChannel.BasicPublishAsync(exchange: this.options.ExchangeName, eventName,
            body: Encoding.UTF8.GetBytes(body));
        
    }

    private async Task<IChannel> CreateChannel ()
    {
        var channel = await connection.CreateChannelAsync();

        //channel.ExchangeDeclare(this.options.ExchangeName, ExchangeType.Fanout, true);
        await channel.ExchangeDeclareAsync(this.options.ExchangeName, ExchangeType.Direct, true);

        return channel;
    }
}
