namespace Domain.Entities
{
    public class ShoppingCartItem
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public Product Product { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
