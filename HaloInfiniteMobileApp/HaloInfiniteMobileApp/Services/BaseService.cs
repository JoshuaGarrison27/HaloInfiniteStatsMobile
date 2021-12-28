using Akavache;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace HaloInfiniteMobileApp.Services;

public class BaseService
{
    protected IBlobCache Cache;

    public BaseService(IBlobCache cache)
    {
        Cache = cache ?? BlobCache.LocalMachine;
    }

    public async Task<T> GetFromCache<T>(string cacheName)
    {
        try
        {
            return await Cache.GetObject<T>(cacheName);
        }
        catch (KeyNotFoundException)
        {
            return default;
        }
    }

    public void InvalidateCache()
    {
        Cache.InvalidateAll();
    }

    public void InvalidateCacheKey(string key)
    {
        Cache.Invalidate(key);
    }
}
