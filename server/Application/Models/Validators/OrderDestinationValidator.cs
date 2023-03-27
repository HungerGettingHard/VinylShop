using Application.Models.Requests;
using FluentValidation;

namespace Application.Models.Validators
{
    public class OrderDestinationValidator : AbstractValidator<OrderDestinationRequestDto>
    {
        public OrderDestinationValidator() 
        {
            RuleFor(status => status.Name)
                .NotEmpty()
                .Length(2, 45);
        }
    }
}
