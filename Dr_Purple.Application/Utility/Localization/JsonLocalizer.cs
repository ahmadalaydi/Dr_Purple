using Dr_Purple.Domain.Localization;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Text.Json;

namespace Dr_Purple.Application.Utility.Localization;

public class JsonLocalizer : IJsonLocalizer
{
    private readonly IDistributedCache _cache;
    private readonly JsonSerializerOptions _serializerOptions = new();

    public JsonLocalizer(IDistributedCache cache) => _cache = cache;

    public LocalizedString this[string name]
    {
        get
        {
            string value = GetString(name).Result;
            return new(name, value ?? name, value is null);
        }
    }

    public LocalizedString this[string name, params object[] arguments]
    {
        get
        {
            var actualValue = this[name];
            return !actualValue.ResourceNotFound
                ? new(name, string.Format(actualValue.Value, arguments), false)
                : actualValue;
        }
    }

    public async IAsyncEnumerable<LocalizedString> GetAllStrings()
    {
        string filePath = $"Resources/{CultureInfo.CurrentCulture.Name}.json";
        using FileStream stream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        var dictionary = await JsonSerializer.DeserializeAsync<Dictionary<string, string>>(stream, _serializerOptions);

        foreach (var kvp in dictionary!)
        {
            yield return new(kvp.Key, kvp.Value, false);
        }
    }
    private async Task<string> GetString(string key)
    {
        string relativeFilePath = $"Localization/Resources/{CultureInfo.CurrentCulture.Name}.json";
        string fullFilePath = Path.GetFullPath(relativeFilePath);
        if (File.Exists(fullFilePath))
        {
            string cacheKey = $"locale_{CultureInfo.CurrentCulture.Name}_{key}";
            string cacheValue = await _cache.GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cacheValue))
                return cacheValue!;

            string result = await GetValueFromJSON(key, Path.GetFullPath(relativeFilePath));
            await _cache.SetStringAsync(cacheKey, result!);

            return result;
        }
        return default!;
    }

    private async Task<string> GetValueFromJSON(string propertyName, string filePath)
    {
        if (propertyName is null || filePath is null)
            return default!;

        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        var dictionary = await JsonSerializer.DeserializeAsync<Dictionary<string, string>>(stream, _serializerOptions);

        return dictionary!.TryGetValue(propertyName, out var value) ?
            value : default!;
    }
}