using Application.Models.Requests;
using Application.Models.Responses;

namespace Application.Interfaces
{
    /// <summary>
    /// CRUD service for shopping carts
    /// </summary>
    public interface IShoppingCartService
    {
        public ShoppingCartResponseDto GetShoppingCart(Guid personId);

        public void SetShoppingCartItem(AddShoppingCartRequestDto shoppingCartItemDto);

        public void DeleteShoppingCartItemById(Guid id);

        public void UpdateShoppingCartItem(Guid id, UpdateShoppingCartRequestDto shoppingCartItemDto);
    }
}
