namespace Application.Models.Responses
{
    public class OrderResponseDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public ICollection<OrderItemResponseDto> OrderItems { get; set; }
    }
    public class OrderItemResponseDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
    }

}
