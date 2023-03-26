using Application.Models.Requests;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        public string CreateToken(PersonRequestDto person);

        public void RegisterPerson(RegisterPersonRequestDto personRequest);
    }
}
