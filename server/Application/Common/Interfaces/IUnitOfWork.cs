using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IUnitOfWork 
    {
        public IGenericRepository<Genre> GenreRepository { get; }
        public IGenericRepository<Person> PersonRepository { get; }
        public IGenericRepository<Product> ProductRepository { get; }
        public IGenericRepository<ShoppingCart> ShoppingCartRepository { get; }
        public IGenericRepository<ShoppingCartItem> ShoppingCartItemRepository { get; }
        public IGenericRepository<OrderStatus> OrderStatusRepository { get; }
        public IGenericRepository<OrderDestination> OrderDestinationRepository { get; }
    }
}
