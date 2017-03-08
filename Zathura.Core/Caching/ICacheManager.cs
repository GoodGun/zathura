using System;
using System.Collections.Generic;

namespace Zathura.Core.Caching
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        T Get<T>(string key);

        /// <summary>
        /// Try to get value of key.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="isSucceeded">Key exists status</param>
        /// <returns>The value associated with the specified key.</returns>
        T Get<T>(string key, out bool isSucceeded);

        IDictionary<String, T> Get<T>(IList<string> keys);
        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        void Add<T>(string key, T value) where T : class;

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <param name="timeout">Timout</param>
        void Add<T>(string key, T value, TimeSpan timeout) where T : class;

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">Cache time</param>
        void Add<T>(string key, T value, int cacheTime) where T : class;


        
        /// <summary>
        /// Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Result</returns>
        bool IsSet(string key);

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">/key</param>
        void Remove(string key);

        /// <summary>
        /// Removes items by pattern
        /// </summary>
        /// <param name="pattern">pattern</param>
        void RemoveByPattern(string pattern);

        /// <summary>
        /// Clear all cache data
        /// </summary>
        void Clear();

        /// <summary>
        /// Update item in list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listkey"></param>
        /// <param name="value"></param>
        void Update<T>(string listkey, T value);
    }
}
