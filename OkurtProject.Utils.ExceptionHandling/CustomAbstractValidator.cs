using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace OkurtProject.Utils.ExceptionHandling
{
    public class CustomAbstractValidator<T> : AbstractValidator<T>
    {
        public new ValidationResult Validate(T instance)
        {
            if (object.Equals(instance, default(T)))
            {
                throw new ApiException(string.Format("Empty {0} request.", typeof(T).Name));
            }

            var validationResult = base.Validate(instance);

            if (!validationResult.IsValid)
            {
                throw new ApiException(validationResult.Errors.Select(p => p.ErrorMessage));
            }

            return validationResult;
        }
    }
}
