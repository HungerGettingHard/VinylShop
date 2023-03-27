namespace Application.Models.Requests
{
    public class AddShoppingCartRequestDto
    {
        public Guid ProductId { get; set; }
        public Guid ShoppingCartId { get; set; }
    }
}
