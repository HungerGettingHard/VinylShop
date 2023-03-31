using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<OrderDestination> _orderDestinationRepository;
        private readonly IGenericRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IGenericRepository<ShoppingCartItem> _shoppingCartItemRepository;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _orderRepository = unitOfWork.OrderRepository;
            _orderDestinationRepository = unitOfWork.OrderDestinationRepository;
            _shoppingCartRepository = unitOfWork.ShoppingCartRepository;
            _shoppingCartItemRepository = unitOfWork.ShoppingCartItemRepository;
        }

        public List<OrderResponseDto> GetAllOrders()
        {
            return _orderRepository.GetList()
                .Include(order => order.Person)
                .Include(order => order.OrderItems)
                .Include(order => order.Products)
                .Select(order => new OrderResponseDto
            {
                Id = order.Id,
                PersonId = order.Person.Id,
                OrderItems = order.OrderItems.Select(item => new OrderItemResponseDto
                {
                    Id = item.Id,
                    Amount = item.Amount,
                    ProductName = item.Product.Name,
                    ImageLink = item.Product.ImageLink,
                    Price = item.Product.Price,
                }).ToList()
            }).ToList();
        }

        public void MakeOrder(MakeOrderRequest request)
        {
            // ToDo: Add validation

            var cart = _shoppingCartRepository.GetList()
                .Include(cart => cart.Products)
                .Include(cart => cart.Person)
                .FirstOrDefault(cart => cart.Id == request.ShoppingCartId);
            if (cart == null)
                throw new NotFoundException(nameof(ShoppingCart), request.ShoppingCartId);

            var items = cart.ShoppingCartItems.Select(item => new OrderItem
            {
                Amount = item.Amount,
                Product = item.Product
            }).ToList();

            if (items.Count == 0)
                throw new ShoppingCartEmptyException(request.ShoppingCartId);

            var destination = _orderDestinationRepository.GetByID(request.OrderDestinationId);
            if (destination == null)
                throw new NotFoundException(nameof(OrderDestination), request.OrderDestinationId);

            foreach (var cartItem in cart.ShoppingCartItems)
            {
                _shoppingCartItemRepository.Delete(cartItem);
            }

            _orderRepository.Insert(new Order()
            {
                OrderDestination = destination,
                OrderItems = items,
                Person = cart.Person
            });
        }
    }
}
