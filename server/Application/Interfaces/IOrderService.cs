using Application.Models.Requests;
using Application.Models.Responses;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        public List<OrderResponseDto> GetAllOrders();
        public void MakeOrder(MakeOrderRequest request);
    }
}
