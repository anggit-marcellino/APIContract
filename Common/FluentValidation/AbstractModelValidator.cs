using FluentValidation;

namespace Common.FluentValidation
{
    public abstract class AbstractModelValidator<T> : AbstractValidator<T> where T : class { }
}
