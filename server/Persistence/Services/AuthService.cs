using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Interfaces;
using Application.Models.Requests;
using Domain.Entities;
using Isopoh.Cryptography.Argon2;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Persistence.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<Person> _personRepository;
        private readonly IGenericRepository<ShoppingCart> _cartRepository;
        private readonly IValidationService<PersonRequestDto> _personValidator;
        private readonly IValidationService<RegisterPersonRequestDto> _registerValidator;
        private readonly AuthOptions _options;

        public AuthService(IUnitOfWork unitOfWork, IValidationService<PersonRequestDto> personValidator,
            IValidationService<RegisterPersonRequestDto> registerValidator, IOptions<AuthOptions> options)
        {
            _personRepository = unitOfWork.PersonRepository;
            _cartRepository = unitOfWork.ShoppingCartRepository;
            _personValidator = personValidator;
            _registerValidator = registerValidator;
            _options = options.Value;
        }

        public string CreateToken(PersonRequestDto personRequest)
        {
            _personValidator.Validate(personRequest);

            ValidatePersonCredentialsAndThrow(personRequest);

            var key = Encoding.ASCII.GetBytes(_options.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, "User"),
                        new Claim(JwtRegisteredClaimNames.Email, "Email"),
                        new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _options.Issuer,
                Audience = _options.Audience,
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;
        }

        public void RegisterPerson(RegisterPersonRequestDto personRequest)
        {
            _registerValidator.Validate(personRequest);

            var isLoginExist = _personRepository.GetList()
                .Any(person => person.Login == personRequest.Login);

            if (isLoginExist)
                throw new LoginAlreadyExistsException(personRequest.Login);

            var cart = new ShoppingCart();

            _cartRepository.Insert(cart);
            _personRepository.Insert(new Person
            {
                Name = personRequest.Name,
                Login = personRequest.Login,
                Password = Argon2.Hash(personRequest.Password),
                ShoppingCart = cart
            });
        }

        private void ValidatePersonCredentialsAndThrow(PersonRequestDto personRequest)
        {
            var person = _personRepository.GetList()
                .Where(person => person.Login == personRequest.Login)
                .FirstOrDefault();

            if (person == null)
                throw new LoginNotExistsException(personRequest.Login);

            if (!Argon2.Verify(person.Password, personRequest.Password))
                throw new InvalidPasswordException();
        }
    }
}
