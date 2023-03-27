using Application.Models.Requests;
using FluentValidation;

namespace Application.Models.Validators
{
    public class OrderStatusValidator : AbstractValidator<OrderStatusRequestDto>
    {
        public OrderStatusValidator() 
        {
            RuleFor(status => status.Name)
                .NotEmpty()
                .Length(2, 45);
        }
    }
}
