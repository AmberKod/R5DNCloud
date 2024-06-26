using CSRedis;
using R5DNCloud.Infrastructure.Models;

namespace R5DNCloud.Redis;

public interface IRedisService
{
    /// <summary>
    /// 查看服务是否运行
    /// </summary>
    /// <returns></returns>
    Task<bool> PingAsync();
    
    /// <summary>
    /// 根据key获取缓存
    /// </summary>
    /// <param name="key"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task<T> GetAsync<T>(string key);
    
    /// <summary>
    /// 设置指定key对的缓存值(不过期)
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    Task<bool> SetAsync(string key, object value);

    /// <summary>
    /// 设置指定key的缓存值(可设置过期时间和Nx、Xx)
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="expire"></param>
    /// <param name="exists"></param>
    /// <returns></returns>
    Task<bool> SetAsync(string key, object value, TimeSpan expire, RedisExistence? exists = null);

    /// <summary>
    /// 设置指定key的缓存值(可设置过期时间和Nx、Xx)
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="expireSeconds">过期时间单位为秒</param>
    /// <param name="exists"></param>
    /// <returns></returns>
    Task<bool> SetAsync(string key, object value, int expireSeconds = -1, RedisExistence? exists = null);

    /// <summary>
    /// 删除key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<long> DeleteAsync(string key);

    Task<dynamic> ScanAsync(PagedQueryModelBase model);

}