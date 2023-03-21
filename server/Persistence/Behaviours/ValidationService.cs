using Application.Common.Interfaces;
using FluentValidation;
using ValidationException = Application.Common.Exceptions.ValidationException;

namespace Persistence.Behaviours
{
    public class ValidationService<TRequest> : IValidationService<TRequest>
        where TRequest : class
    {
        private readonly IValidator<TRequest> _validator;

        public ValidationService(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public void Validate(TRequest request)
        {
            var validationResult = _validator.Validate(request);

            if (validationResult.Errors.Count != 0)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
