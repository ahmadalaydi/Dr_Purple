using Dr_Purple.Domain.Localization;
using Microsoft.Extensions.Caching.Distributed;

namespace Dr_Purple.Application.Utility.Localization;

public class JsonLocalizerFactory : IJsonLocalizerFactory
{
    private readonly IDistributedCache _cache;

    public JsonLocalizerFactory(IDistributedCache cache) => _cache = cache;

    public IJsonLocalizer Create(Type resourceSource) => new JsonLocalizer(_cache);

    public IJsonLocalizer Create(string baseName, string location) => new JsonLocalizer(_cache);
}