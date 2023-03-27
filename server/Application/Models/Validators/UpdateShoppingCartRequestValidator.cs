using Application.Models.Requests;
using FluentValidation;

namespace Application.Models.Validators
{
    public class UpdateShoppingCartRequestValidator : AbstractValidator<UpdateShoppingCartRequestDto>
    {
        public UpdateShoppingCartRequestValidator()
        {
            RuleFor(cart => cart.Amount)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
