namespace Application.Common.Exceptions
{
    public class CartItemAlreadyExistsException : Exception
    {
        public CartItemAlreadyExistsException(Guid cartId, Guid productId)
            : base($"Cart item from cart '{cartId}' with product '{productId}' already exists")
        {
        }
    }
}
