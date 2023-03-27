using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace VinylShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Gets list of all Orders.
        /// </summary>
        /// <returns>Order list</returns>
        /// <response code="200">OK</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<OrderResponseDto>> GetAllOrders()
        {
            return _orderService.GetAllOrders();
        }

        ///// <summary>
        ///// Gets Order status by it's Id.
        ///// </summary>
        ///// <returns>Order status</returns>
        ///// <response code="200">OK</response>
        ///// <response code="404">NotFound</response>
        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<OrderStatusResponseDto> GetOrderStatusById(Guid id)
        //{
        //    return _orderStatusService.GetOrderStatusById(id);
        //}

        /// <summary>
        /// Creates new Order.
        /// </summary>
        /// <response code="204">NoContent</response>
        /// <response code="400">BadRequest</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult MakeOrder(MakeOrderRequest request)
        {
            _orderService.MakeOrder(request);
        
            return NoContent();
        }

        ///// <summary>
        ///// Updates Order status by it's id.
        ///// </summary>
        ///// <response code="200">OK</response>
        ///// <response code="400">BadRequest</response>
        ///// <response code="404">NotFound</response>
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult UpdateOrderStatus(Guid id, OrderStatusRequestDto orderStatus)
        //{
        //    _orderStatusService.UpdateOrderStatus(id, orderStatus);
         
        //    return Ok();
        //}

        ///// <summary>
        ///// Deletes Order status by it's Id.
        ///// </summary>
        ///// <response code="204">NoContent</response>
        ///// <response code="404">NotFound</response>
        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult DeleteOrderStatusById(Guid id)
        //{
        //    _orderStatusService.DeleteOrderStatusById(id);
         
        //    return NoContent();
        //}
    }
}
