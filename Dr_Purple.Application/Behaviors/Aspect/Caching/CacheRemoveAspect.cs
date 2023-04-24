using Castle.DynamicProxy;
using Dr_Purple.Application.Behaviors.CrossCuttingConcerns.Caching;
using Dr_Purple.Application.Utility.Interceptors;

namespace Dr_Purple.Application.Behaviors.Aspect.Caching;
public class CacheRemoveAspect : MethodInterseption
{
    private readonly string _pattern;
    private readonly ICacheManager _cache;
    public CacheRemoveAspect(string pattern, ICacheManager cacheManager)
        => (_pattern, _cache) = (pattern, cacheManager);


    protected override void OnSuccsess(IInvocation invocation)
    {
        _cache.RemoveByPattern(_pattern);
    }
}

