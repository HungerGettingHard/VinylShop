using Application.Models.Requests;
using FluentValidation;

namespace Application.Models.Validators
{
    public class AddShoppingCartRequestValidator : AbstractValidator<AddShoppingCartRequestDto>
    {
        public AddShoppingCartRequestValidator()
        {
            RuleFor(cart => cart.ShoppingCartId)
                .NotEmpty();

            RuleFor(cart => cart.ProductId)
                .NotEmpty();
        }
    }
}
