using Application.Models.Requests;
using FluentValidation;

namespace Application.Models.Validators
{
    public class GenreRequestValidator : AbstractValidator<GenreRequestDto>
    {
        public GenreRequestValidator() 
        {
            RuleFor(genre => genre.Name).Length(2, 45);
        }
    }
}
