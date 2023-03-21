namespace Application.Common.Interfaces
{
    public interface IValidationService<TRequest>
        where TRequest : class
    {
        public void Validate(TRequest request);
    }
}
