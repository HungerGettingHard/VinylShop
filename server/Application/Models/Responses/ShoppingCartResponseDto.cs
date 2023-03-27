using Domain.Entities;

namespace Application.Models.Responses
{
    public class ShoppingCartResponseDto
    {
        public Guid Id { get; set; }
        public ICollection<ShoppingCartItemResponseDto> Items { get; set; }
    }

    public class ShoppingCartItemResponseDto
    {
        public Guid CartItemId { get; set; }
        public int Amount { get; set; } 
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
