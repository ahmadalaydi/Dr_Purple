using Castle.DynamicProxy;
using Dr_Purple.Application.Utility.Interceptors;
using System.Diagnostics;

namespace Dr_Purple.Application.Behaviors.Aspect.Performance;
public class PerformanceAspect : MethodInterseption
{
    public int? _interval;
    private readonly Stopwatch? _stopwatch;
    public PerformanceAspect(int interval, Stopwatch stopwatch)
        => (_interval, _stopwatch) = (interval, stopwatch);

    protected override void OnBefore(IInvocation? invocation) => _stopwatch!.Start();

    protected override void OnAfter(IInvocation? invocation)
    {
        if (_stopwatch!.Elapsed.TotalSeconds > _interval)
            Debug.WriteLine($"Performance : {invocation!.Method.DeclaringType!.FullName}" +
                $".{invocation.Method.Name} --> {_stopwatch.Elapsed.TotalSeconds}");

        _stopwatch.Reset();
    }
}

