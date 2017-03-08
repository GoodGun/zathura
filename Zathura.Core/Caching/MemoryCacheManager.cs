using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace Zathura.Core.Caching
{
    public partial class MemoryCacheManager : IMemoryCacheManager
    {
        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }
        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }
        public  void Add<T>(string key, T value, TimeSpan timeout) where T : class
        {
            if (value == null)
                return;

            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = new DateTimeOffset(DateTime.UtcNow.AddSeconds(timeout.TotalSeconds));//  DateTime.Now + timeout;
         
            Cache.Add(new CacheItem(key, value), policy);
        }
        public void Add<T>(string key, T value, int cacheTime) where T : class
        {
            if (value == null)
                return;

            var policy = new CacheItemPolicy();

            policy.AbsoluteExpiration = new DateTimeOffset(DateTime.UtcNow.AddSeconds(cacheTime));
            Cache.Add(new CacheItem(key, value), policy);
        }        
        public void Add<T>(string key, T value) where T : class
        {
            if (value == null)
                return;

            var policy = new CacheItemPolicy();
            Cache.Add(new CacheItem(key, value), policy);
        }
        public bool IsSet(string key)
        {
            return (Cache.Contains(key));
        }
        public void Remove(string key)
        {
            Cache.Remove(key);
        }
        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();

            foreach (var item in Cache)
                if (regex.IsMatch(item.Key))
                    keysToRemove.Add(item.Key);

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }
        }
        public void Clear()
        {
            foreach (var item in Cache)
                Remove(item.Key);
        }
        public T Get<T>(string key, out bool isSucceeded)
        {
            throw new NotImplementedException();
        }
        public IDictionary<string, T> Get<T>(IList<string> keys)
        {
            throw new NotImplementedException();
        }
        public void Update<T>(string listkey, T value)
        {
            throw new NotImplementedException();
        }
    }
}
