﻿namespace Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public OrderDestination OrderDestination { get; set; }
        public Person Person { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
