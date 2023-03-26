using Application.Models.Requests;
using FluentValidation;

namespace Application.Models.Validators
{
    public class PersonRequestValidator : AbstractValidator<PersonRequestDto>
    {
        public PersonRequestValidator()
        {
            RuleFor(person => person.Login).NotEmpty();
            RuleFor(person => person.Password).NotEmpty();
        }
    }
}
