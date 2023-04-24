using Castle.DynamicProxy;
using Dr_Purple.Application.Behaviors.CrossCuttingConcerns.Logging;
using Dr_Purple.Application.Utility.Interceptors;

namespace Dr_Purple.Application.Behaviors.Aspect.Logging;
public class LogAspect : MethodInterseption
{
    private readonly LoggerServiceBase? _loggerServiceBase;
    public LogAspect(Type loggerService)
    {
        if (loggerService.BaseType != typeof(LoggerServiceBase))
        {
            throw new Exception("Wrong Logger Type");
        }

        _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService)!;
    }

    protected override void OnBefore(IInvocation? invocation)
    {
        _loggerServiceBase!.Info(GetLogDetail(invocation!));
    }

    private static object GetLogDetail(IInvocation invocation)
    {
        var logParameters = new List<LogParameter>();

        for (int i = 0; i < invocation.Arguments.Length; i++)
        {
            logParameters.Add(new LogParameter
            {
                Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                Value = invocation.Arguments[i],
                Type = invocation.Arguments[i].GetType().Name
            });
        }

        var logDetial = new LogDetail
        {
            Target = invocation.InvocationTarget?.ToString(),
            MethodName = invocation.Method.Name,
            LogParameters = logParameters
        };

        return logDetial;
    }
}
