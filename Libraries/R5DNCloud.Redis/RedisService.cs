using System.Dynamic;
using CSRedis;
using R5DNCloud.Infrastructure;
using R5DNCloud.Infrastructure.Models;

namespace R5DNCloud.Redis;

public class RedisService: IRedisService, IScopedDependency
{
    public async Task<bool> PingAsync()
    {
        return await RedisHelper.PingAsync();
    }

    public async Task<T> GetAsync<T>(string key)
    {
        return await RedisHelper.GetAsync<T>(key);
    }

    public async Task<bool> SetAsync(string key, object value)
    {
        return await RedisHelper.SetAsync(key, value);
    }

    public async Task<bool> SetAsync(string key, object value, TimeSpan expire, RedisExistence? exists = null)
    {
        return await RedisHelper.SetAsync(key, value, expire, exists);
    }

    public async Task<bool> SetAsync(string key, object value, int expireSeconds = -1, RedisExistence? exists = null)
    {
        return await RedisHelper.SetAsync(key, value, expireSeconds, exists);
    }

    public async Task<long> DeleteAsync(string key)
    {
        return await RedisHelper.DelAsync(key);
    }

    public async Task<dynamic> ScanAsync(PagedQueryModelBase model)
    {
        List<string> list = new List<string>();
        
        // 根据 model.Keyword 进行模糊匹配
        var scanResult = await RedisHelper.ScanAsync(model.Page, $"*{model.Keyword}*", model.Limit);
        list.AddRange(scanResult.Items);
        
        var values = await RedisHelper.MGetAsync(list.ToArray());

        var resultDictionary = list.Zip(values, (key, value) => new { key, value })
            .ToDictionary(item => item.key, item => item.value);
        dynamic result = new ExpandoObject();
        result.Items = resultDictionary;
        result.Cursor = scanResult.Cursor;    // 下一次要通过这个Cursor获取下一页的keys
        return result;
    }
}