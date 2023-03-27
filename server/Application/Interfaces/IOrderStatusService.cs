using Application.Models.Requests;
using Application.Models.Responses;

namespace Application.Interfaces
{
    /// <summary>
    /// CRUD service for order statuses
    /// </summary>
    public interface IOrderStatusService
    {
        public List<OrderStatusResponseDto> GetAllOrderStatuses();

        public OrderStatusResponseDto GetOrderStatusById(Guid id);

        public void SetOrderStatus(OrderStatusRequestDto orderStatusDto);

        public void DeleteOrderStatusById(Guid id);

        public void UpdateOrderStatus(Guid id, OrderStatusRequestDto orderStatusDto);
    }
}
