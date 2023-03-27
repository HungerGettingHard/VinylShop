namespace Domain.Entities
{
    public class Product
    {
        public Product()
        {
            Genres = new HashSet<Genre>();
            ShoppingCarts = new HashSet<ShoppingCart>();
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
            OrderItems = new HashSet<OrderItem>();
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
