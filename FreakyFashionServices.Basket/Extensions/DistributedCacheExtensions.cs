using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreakyFashionServices.Basket.Extensions
{
    public static class DistributedCacheExtensions
    {
        public static object JsonSearlizer { get; private set; }
        public static async Task SetRecordAsync<T>(this IDistributedCache cache,
            string recordId,
            T data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? unusedExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromMinutes(5);
            options.SlidingExpiration = unusedExpireTime;

            var json = JsonSerializer.Serialize(data);

            await cache.SetStringAsync(recordId, json, options);
        }

        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordId)
        {
            var json = await cache.GetStringAsync(recordId);
            if (json is null)
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(json);
            //return json is null ? default(T) : JsonSerializer.Deserialize<T>(json);
        }

    }
}
