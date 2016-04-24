using System;

namespace UniQode.Contracts.Providers
{
    public interface ICacheProvider
    {
        TimeSpan Ttl { get; }

        T Get<T>(string key, string regionName = null);

        void Set(string key, object data, string regionName = null, TimeSpan? ttl = null);

        bool IsSet(string key);

        void Invalidate(string key);

        void Clear();
    }
}