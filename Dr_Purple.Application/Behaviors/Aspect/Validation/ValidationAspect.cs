using Castle.DynamicProxy;
using Dr_Purple.Application.Behaviors.CrossCuttingConcerns.Validation;
using Dr_Purple.Application.Utility.Interceptors;
using Dr_Purple.Application.Utility.Messages;
using FluentValidation;

namespace Dr_Purple.Application.Behaviors.Aspect.Validation;
public class ValidationAspect : MethodInterseption
{
    private readonly Type? _validatorType;

    public ValidationAspect(Type? validatorType)
    {
        if (!typeof(IValidator).IsAssignableFrom(validatorType))
        {
            throw new Exception(CoreMessages.WrongValidationType);
        }

        _validatorType = validatorType;
    }

    protected override void OnBefore(IInvocation? invocation)
    {
        var validator = Activator.CreateInstance(_validatorType!) as IValidator;
        var entityType = _validatorType!.BaseType!.GetGenericArguments()[0];
        var entities = invocation!.Arguments.Where(t => t.GetType() == entityType);

        foreach (var entity in entities)
        {
            ValidationTool.Validate(validator!, entity);
        }
    }
}

