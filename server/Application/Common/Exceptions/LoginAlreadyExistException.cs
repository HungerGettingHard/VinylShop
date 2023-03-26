namespace Application.Common.Exceptions
{
    public class LoginAlreadyExistException : Exception
    {
        public LoginAlreadyExistException(string login)
            : base($"Login '{login}' already exists")
        {
        }
    }
}
