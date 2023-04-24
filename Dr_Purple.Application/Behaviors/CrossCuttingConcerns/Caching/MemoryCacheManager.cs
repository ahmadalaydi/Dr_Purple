using Microsoft.Extensions.Caching.Memory;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Dr_Purple.Application.Behaviors.CrossCuttingConcerns.Caching;
public class MemoryCacheManager : ICacheManager
{
    private readonly IMemoryCache _cache;

    public MemoryCacheManager(IMemoryCache cache)
    => _cache = cache;

    public void Add(string key, object data, int duration)
    => _cache.Set(key, data, TimeSpan.FromMinutes(duration));

    public T Get<T>(string key) => _cache.Get<T>(key);

    public object Get(string key) => _cache.Get(key);

    public bool IsAdd(string key) => _cache.TryGetValue(key, out _);

    public void Remove(string key) => _cache.Remove(key);

    public void RemoveByPattern(string pattern)
    {
        var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
        var cacheEntriesCollection = cacheEntriesCollectionDefinition!.GetValue(_cache)! as dynamic;
        List<ICacheEntry> cacheCollectionValues = new();

        foreach (var cacheItem in cacheEntriesCollection)
        {
            ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
            cacheCollectionValues.Add(cacheItemValue);
        }

        var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
        var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString()!)).Select(d => d.Key).ToList();

        foreach (var key in keysToRemove)
            _cache.Remove(key);
    }
}

