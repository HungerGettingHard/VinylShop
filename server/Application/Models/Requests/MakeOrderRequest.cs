namespace Application.Models.Requests
{
    public class MakeOrderRequest
    {
        public Guid ShoppingCartId { get; set; }
        public Guid OrderDestinationId { get; set; }
    }
}
