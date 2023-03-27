using Persistence.DbContext;
using Domain.Entities;
using Application.Common.Interfaces;

namespace Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly VinylShopDbContext _context;
        private GenericRepository<Genre> _genreRepository;
        private GenericRepository<Person> _personRepository;
        private GenericRepository<Product> _productRepository;
        private GenericRepository<ShoppingCart> _shoppingCartRepository;
        private GenericRepository<ShoppingCartItem> _shoppingCartItemRepository;
        private GenericRepository<OrderStatus> _orderStatusRepository;

        public UnitOfWork(VinylShopDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Genre> GenreRepository => _genreRepository ??= new GenericRepository<Genre>(_context);
        public IGenericRepository<Person> PersonRepository => _personRepository ??= new GenericRepository<Person>(_context);
        public IGenericRepository<Product> ProductRepository => _productRepository ??= new GenericRepository<Product>(_context);
        public IGenericRepository<ShoppingCart> ShoppingCartRepository => _shoppingCartRepository ??= new GenericRepository<ShoppingCart>(_context);
        public IGenericRepository<ShoppingCartItem> ShoppingCartItemRepository => _shoppingCartItemRepository ??= new GenericRepository<ShoppingCartItem>(_context);
        public IGenericRepository<OrderStatus> OrderStatusRepository => _orderStatusRepository ??= new GenericRepository<OrderStatus>(_context);

        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
