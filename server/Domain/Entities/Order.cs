namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public OrderDestination OrderDestination { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
