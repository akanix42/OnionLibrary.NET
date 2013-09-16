using FluentValidation;
using FluentValidation.Results;

namespace LayeredDev.BLL
{
    public interface IModel<T>
    {
        ValidationResult Validate();
        ValidationResult Validate<TValidator>() where TValidator : IValidator, new();
    }
}