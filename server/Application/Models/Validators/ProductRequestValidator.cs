using Application.Models.Requests;
using FluentValidation;

namespace Application.Models.Validators
{
    public class ProductRequestValidator : AbstractValidator<ProductRequestDto>
    {
        public ProductRequestValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty();
        }
    }
}
