namespace Domain.Entities
{
    public class OrderDestination
    {
        public OrderDestination()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
