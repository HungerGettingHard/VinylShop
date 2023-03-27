using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.DbContext
{
    public interface IVinylShopDbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
    }
}
