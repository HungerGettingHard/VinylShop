namespace Application.Common.Exceptions
{
    public class ShoppingCartEmptyException : Exception
    {
        public ShoppingCartEmptyException(Guid cartId)
            : base($"Shopping cart '{cartId}' is empty")
        {
        }
    }
}
