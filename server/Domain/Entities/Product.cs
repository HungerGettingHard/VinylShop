﻿namespace Domain.Entities
{
    public class Product
    {
        public Product()
        {
            Genres = new HashSet<Genre>();
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
