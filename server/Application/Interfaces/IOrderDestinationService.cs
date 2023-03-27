using Application.Models.Requests;
using Application.Models.Responses;

namespace Application.Interfaces
{
    /// <summary>
    /// CRUD service for order destinations
    /// </summary>
    public interface IOrderDestinationService
    {
        public List<OrderDestinationResponseDto> GetAllOrderDestinations();

        public OrderDestinationResponseDto GetOrderDestinationById(Guid id);

        public void SetOrderDestination(OrderDestinationRequestDto orderStatusDto);

        public void DeleteOrderDestinationById(Guid id);

        public void UpdateOrderDestination(Guid id, OrderDestinationRequestDto orderStatusDto);
    }
}
