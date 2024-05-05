using Castle.DynamicProxy;
using Dr_Purple.Application.Utility.Interceptors;
using System.Transactions;

namespace Dr_Purple.Application.Behaviors.Aspect.Transaction;
public class TransactionScopeAspect : MethodInterseption
{
    public override void Intercept(IInvocation invocation)
    {
        using TransactionScope transactionScope = new(TransactionScopeOption.Required, TimeSpan.FromMinutes(10));
        try
        {
            invocation.Proceed();
            transactionScope.Complete();
        }
        catch (Exception)
        {
            transactionScope.Dispose();
            throw;
        }
    }
}

