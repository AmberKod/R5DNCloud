using CSRedis;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace R5DNCloud.Redis;

public static partial class ServiceCollectionExtensions
{
    /// <summary>
    /// 初始化Redis配置
    /// </summary>
    /// <param name="app"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseRedis(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.AddRedis(options =>
        {
            options.ConnectionString = configuration.GetSection("Redis:ConnectionString").Value ?? "";
        });
        return app;
    }

    /// <summary>
    /// 初始化Redis配置
    /// </summary>
    /// <param name="app"></param>
    /// <param name="configureOption"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private static IApplicationBuilder AddRedis(this IApplicationBuilder app, Action<RedisOption> configureOption)
    {
        RedisOption options = new();
        configureOption(options);
        var redisConnectionString = options.ConnectionString;
        if (string.IsNullOrWhiteSpace(redisConnectionString))
        {
            throw new Exception("Redis连接字符串不能为空");
        }

        var csRedis = new CSRedisClient(redisConnectionString);
        RedisHelper.Initialization(csRedis);
        return  app;
    }
}

public class RedisOption
{
    public string ConnectionString { get; set; }

    public bool UseKeyEventNotify { get; set; } = false;
}