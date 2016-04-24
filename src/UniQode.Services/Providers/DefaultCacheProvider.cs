using System;
using System.Runtime.Caching;
using UniQode.Contracts.Providers;

namespace UniQode.Services.Providers
{
    public class DefaultCacheProvider : ICacheProvider
    {
        public DefaultCacheProvider(TimeSpan? ttl = null)
        {
            Ttl = ttl ?? TimeSpan.FromMinutes(60);
            _cache = MemoryCache.Default;
        }

        ~DefaultCacheProvider()
        {
            _cache.Dispose();
        }

        public TimeSpan Ttl { get; }

        private MemoryCache _cache;


        public T Get<T>(string key, string regionName = null)
        {
            return (T)_cache.Get(key, regionName);
        }

        public void Set(string key, object data, string regionName = null, TimeSpan? ttl = null)
        {
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now + (ttl ?? Ttl)
            };

            var item = new CacheItem(key, data, regionName);

            if (_cache.Contains(key, regionName))
                _cache.Set(item, policy);
            else
                _cache.Add(new CacheItem(key, data, regionName), policy);
        }

        public bool IsSet(string key)
        {
            return _cache.Contains(key);
        }

        public void Invalidate(string key)
        {
            _cache.Remove(key);
        }

        public void Clear()
        {
            _cache.Dispose();
            _cache = MemoryCache.Default;
        }
    }
}