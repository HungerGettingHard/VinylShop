using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IGenericRepository<Person> _personRepository;
        private readonly IGenericRepository<ShoppingCart> _cartRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ShoppingCartItem> _cartItemRepository;
        private readonly IValidationService<AddShoppingCartRequestDto> _addValidator;
        private readonly IValidationService<UpdateShoppingCartRequestDto> _updateValidator;

        public ShoppingCartService(IUnitOfWork unitOfWork, IValidationService<AddShoppingCartRequestDto> addValidator,
            IValidationService<UpdateShoppingCartRequestDto> updateValidator)
        {
            _personRepository = unitOfWork.PersonRepository;
            _cartRepository = unitOfWork.ShoppingCartRepository;
            _productRepository = unitOfWork.ProductRepository;
            _cartItemRepository = unitOfWork.ShoppingCartItemRepository;
            _addValidator = addValidator;
            _updateValidator = updateValidator;
        }

        public ShoppingCartResponseDto GetShoppingCart(Guid personId)
        {
            var person = _personRepository.GetByID(personId);
            if (person == null)
                throw new NotFoundException(nameof(Person), personId);

            var shoppingCart = _cartRepository.GetList()
                .Include(cart => cart.Products)
                .FirstOrDefault(cart => cart.Id == person.ShoppingCartId);
            if (shoppingCart == null)
                throw new NotFoundException(nameof(ShoppingCart), person.ShoppingCartId);

            var shoppingCartItems = shoppingCart.ShoppingCartItems
                .Select(item => new ShoppingCartItemResponseDto
                {
                    CartItemId = item.Id,
                    Amount = item.Amount,
                    ProductId = item.Product.Id,
                    ProductName = item.Product.Name
                }).ToArray();

            return new ShoppingCartResponseDto
            {
                Id = shoppingCart.Id,
                Items = shoppingCartItems
            };
        }

        public void SetShoppingCartItem(AddShoppingCartRequestDto shoppingCartItemDto)
        {
            _addValidator.Validate(shoppingCartItemDto);

            var cart = _cartRepository.GetByID(shoppingCartItemDto.ShoppingCartId);
            if (cart == null)
                throw new NotFoundException(nameof(ShoppingCart), shoppingCartItemDto.ShoppingCartId);

            var isAlreadyExists = cart.Products.Any(product => product.Id == shoppingCartItemDto.ProductId);
            if (isAlreadyExists)
                throw new CartItemAlreadyExistsException(shoppingCartItemDto.ShoppingCartId, shoppingCartItemDto.ProductId);


            var product = _productRepository.GetByID(shoppingCartItemDto.ProductId);
            if (product == null)
                throw new NotFoundException(nameof(Product), shoppingCartItemDto.ProductId);

            cart.Products.Add(product);
            _cartRepository.SaveChanges();
        }

        public void UpdateShoppingCartItem(Guid id, UpdateShoppingCartRequestDto shoppingCartItemDto)
        {
            _updateValidator.Validate(shoppingCartItemDto);
            var shoppingCartItem = FindCartItemInRepositoryByIdAndThrow(id);

            shoppingCartItem.Amount = shoppingCartItemDto.Amount;
            _cartItemRepository.SaveChanges();
        }

        public void DeleteShoppingCartItemById(Guid id)
        {
            var cartItem = FindCartItemInRepositoryByIdAndThrow(id);
            _cartItemRepository.Delete(cartItem);
        }

        private ShoppingCartItem FindCartItemInRepositoryByIdAndThrow(Guid id)
        {
            var cartItem = _cartItemRepository.GetByID(id);

            if (cartItem == null)
                throw new NotFoundException(nameof(ShoppingCartItem), id);

            return cartItem;
        }
    }
}
