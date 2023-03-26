using Application.Models.Requests;
using FluentValidation;

namespace Application.Models.Validators
{
    public class RegisterPersonRequestValidator : AbstractValidator<RegisterPersonRequestDto>
    {
        public RegisterPersonRequestValidator()
        {
            RuleFor(person => person.Name)
                .NotEmpty();

            RuleFor(person => person.Login)
                .NotEmpty();

            RuleFor(person => person.Password)
                .NotEmpty()
                .MinimumLength(8);
        }
    }
}
