using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace R5DNCloud.RabbitMQ;

/// <summary>
/// 创建信道
/// </summary>
public class RabbitMqConnection : IRabbitMqConnection
{
    private readonly RabbitOptions options;

    // 通过
    public RabbitMqConnection(IOptions<RabbitOptions> options)
    {
        this.options = options.Value;
    }
    public async Task<IConnection> CreateConnection()
    {
        var factory = new ConnectionFactory
        {
            HostName = this.options.HostName,
            Port = this.options.Port,
            DispatchConsumersAsync = true,  //如果使用AsyncEventingBasicConsumer,
            UserName = this.options.Username,
            Password = this.options.Password,
            VirtualHost = this.options.VirtualHost   //虚拟主机，要在服务器上创建，如果不创建，默认使用"/"，但是不建议使用"/"，因为"/"会和默认的vhost冲突
        };

        // 使用工厂创建连接
        var connection = await factory.CreateConnectionAsync(this.options.ClientName);
        return connection;
    }


    public async Task<IChannel> CreateModel()
    {
        var connection = await CreateConnection();

        return await connection.CreateChannelAsync();
    }
}