using Newtonsoft.Json;
using StackExchange.Redis;

namespace Library.Application.Services;
public class CacheService : ICacheService
{
    private readonly IDatabase _cacheDatabase;

    public CacheService()
    {
        string REDIS_HOST_NAME = Environment.GetEnvironmentVariable("REDIS_HOST_NAME") ?? "redis";
        var redis = ConnectionMultiplexer.Connect($"{REDIS_HOST_NAME}:6379");
        _cacheDatabase = redis.GetDatabase();
    }



    public async ValueTask<T?> GetDataAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        var value = await _cacheDatabase.StringGetAsync(key);
        if (!string.IsNullOrEmpty(value))
        {
            return JsonConvert.DeserializeObject<T>(value,
                new JsonSerializerSettings
                {
                    ContractResolver = new PrivateResolver()
                });
        }
        return default;

    }

    public async ValueTask<bool> RemoveDataAsync(string key, CancellationToken cancellationToken = default)
    {
        bool isExist = await _cacheDatabase.KeyExistsAsync(key);
        if (isExist)
        {
            return await _cacheDatabase.KeyDeleteAsync(key);
        }
        return false;
    }

    public async ValueTask<bool> RefreshDataAsync<T>(string key, T value, TimeSpan expiretime, CancellationToken cancellationToken = default)
    {
        await RemoveDataAsync(key);
        bool isRefreshed = await SetDataAsync<T>(key, value, expiretime);
        return isRefreshed;
    }

    public async ValueTask<bool> SetDataAsync<T>(string key, T value, TimeSpan expiretime, CancellationToken cancellationToken = default)
    {
        bool isSet = await _cacheDatabase.StringSetAsync(key, JsonConvert.SerializeObject(value), expiretime);
        return isSet;
    }
}
