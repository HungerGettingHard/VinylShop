namespace Application.Common.Exceptions
{
    public class LoginNotExistException : Exception
    {
        public LoginNotExistException(string login)
            : base($"Login '{login}' does not exist")
        {
        }
    }
}
