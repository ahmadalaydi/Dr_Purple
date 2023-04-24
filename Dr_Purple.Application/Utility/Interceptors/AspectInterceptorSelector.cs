using Castle.DynamicProxy;
using Dr_Purple.Application.Behaviors.Aspect.Exceptions;
using Dr_Purple.Application.Behaviors.Aspect.Logging;
using Dr_Purple.Application.Behaviors.CrossCuttingConcerns.Logging.Loggers;
using System.Reflection;

namespace Dr_Purple.Application.Utility.Interceptors;
public class AspectInterceptorSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
        var methodAttributes = type.GetMethod(method.Name)!.GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
        classAttributes.AddRange(methodAttributes);
        classAttributes.Add(new ExceptionLogAspect(typeof(JsonFileLogger)));
        classAttributes.Add(new ExceptionLogAspect(typeof(DatabaseLogger)));
        classAttributes.Add(new LogAspect(typeof(DatabaseLogger)));
        return classAttributes.OrderByDescending(x => x.Priority).ToArray();
    }
}