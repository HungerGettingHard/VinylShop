namespace Domain.Entities
{
    public class Person
    {
        public Person()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Login { get;set; }
        public string Password { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
