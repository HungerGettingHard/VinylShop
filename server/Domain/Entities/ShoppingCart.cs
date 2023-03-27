namespace Domain.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Products = new HashSet<Product>();
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        public Guid Id { get; set; }
        public Person Person { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
