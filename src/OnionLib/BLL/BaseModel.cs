using FluentValidation;
using FluentValidation.Results;

namespace LayeredDev.BLL
{
    public abstract class BaseModel<T, U> : IModel<T>
        where T : class, IModel<T>
        where U : AbstractValidator<T>, new()
    {
        public ValidationResult Validate()
        {
            return new U().Validate(this as T);
        }

        public ValidationResult Validate<TValidator>() where TValidator : IValidator,  new() 
        {
            return new TValidator().Validate(this as T);
        }

    }
}
