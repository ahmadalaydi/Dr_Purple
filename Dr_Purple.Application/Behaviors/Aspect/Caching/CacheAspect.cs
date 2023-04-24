using Castle.DynamicProxy;
using Dr_Purple.Application.Behaviors.CrossCuttingConcerns.Caching;
using Dr_Purple.Application.Utility.Interceptors;
using System.Reflection;

namespace Dr_Purple.Application.Behaviors.Aspect.Caching;
public class CacheAspect : MethodInterseption
{
    private readonly int _duration;
    private readonly ICacheManager _cacheManager;
    public CacheAspect(int duration, ICacheManager cacheManager)
        => (_duration, _cacheManager) = (duration, cacheManager);
    public override void Intercept(IInvocation? invocation)
    {
        var methodName = string.Format($"{invocation!.Method.ReflectedType!.FullName}.{invocation.Method.Name}");
        var arguments = GetFieldsOfClass(invocation.Arguments);
        var key = $"{methodName}({arguments})";
        if (_cacheManager.IsAdd(key))
        {
            invocation.ReturnValue = _cacheManager.Get(key);
            return;
        }

        invocation.Proceed();
        _cacheManager.Add(key, invocation.ReturnValue, _duration);
    }

    private static string GetFieldsOfClass(params object[] entity)
    {
        List<string> result = new();
        foreach (var item in entity)
        {
            result.Add(string.Join(",", item.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x?.GetValue(item) != null)
                .Select(x => x?.GetValue(item)).ToList()));
        }

        return string.Join(",", result);
    }
}

