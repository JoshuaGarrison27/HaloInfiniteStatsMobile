using MonkeyCache.FileStore;
using Newtonsoft.Json;
using System;

namespace HaloInfiniteMobileApp.Services
{
    public class BaseService
    {
        public T GetFromCache<T>(string cacheKey)
        {
            try
            {
                return Barrel.Current.Get<T>(cacheKey);
            }
            catch (JsonSerializationException)
            {
                InvalidateCacheKeys(cacheKey);
                return default;
            }
        }

        public void AddToCache<T>(string cacheKey, T data, TimeSpan expireIn)
        {
            Barrel.Current.Add(cacheKey, data, expireIn);
        }

        public void InvalidateCache()
        {
            Barrel.Current.EmptyAll();
        }

        public void InvalidateCacheKeys(params string[] keys)
        {
            Barrel.Current.Empty(keys);
        }
    }
}