using RabbitMQ.Client;

namespace R5DNCloud.RabbitMQ;

public interface IRabbitMqConnection
{
    Task<IConnection> CreateConnection();

    Task<IChannel> CreateModel();
}