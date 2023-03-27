using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace VinylShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDestinationController : Controller
    {
        private readonly IOrderDestinationService _orderDestinationService;

        public OrderDestinationController(IOrderDestinationService orderDestinationService)
        {
            _orderDestinationService = orderDestinationService;
        }

        /// <summary>
        /// Gets list of all Order destinations.
        /// </summary>
        /// <returns>Order destination list</returns>
        /// <response code="200">OK</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<OrderDestinationResponseDto>> GetAllOrderDestinationes()
        {
            return _orderDestinationService.GetAllOrderDestinations();
        }

        /// <summary>
        /// Gets Order destination by it's Id.
        /// </summary>
        /// <returns>Order destination</returns>
        /// <response code="200">OK</response>
        /// <response code="404">NotFound</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDestinationResponseDto> GetOrderDestinationById(Guid id)
        {
            return _orderDestinationService.GetOrderDestinationById(id);
        }

        /// <summary>
        /// Creates new Order destination.
        /// </summary>
        /// <response code="204">NoContent</response>
        /// <response code="400">BadRequest</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateOrderDestination(OrderDestinationRequestDto orderDestination)
        {
            _orderDestinationService.SetOrderDestination(orderDestination);
        
            return NoContent();
        }

        /// <summary>
        /// Updates Order destination by it's id.
        /// </summary>
        /// <response code="200">OK</response>
        /// <response code="400">BadRequest</response>
        /// <response code="404">NotFound</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateOrderDestination(Guid id, OrderDestinationRequestDto orderDestination)
        {
            _orderDestinationService.UpdateOrderDestination(id, orderDestination);
         
            return Ok();
        }

        /// <summary>
        /// Deletes Order destination by it's Id.
        /// </summary>
        /// <response code="204">NoContent</response>
        /// <response code="404">NotFound</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteOrderDestinationById(Guid id)
        {
            _orderDestinationService.DeleteOrderDestinationById(id);
         
            return NoContent();
        }
    }
}
