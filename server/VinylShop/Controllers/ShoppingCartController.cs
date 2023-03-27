using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Persistence.Services;

namespace VinylShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        /// <summary>
        /// Gets Shopping cart for Person.
        /// </summary>
        /// <returns>Shopping cart</returns>
        /// <response code="200">OK</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">NotFound</response>
        [HttpGet("{personId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ShoppingCartResponseDto> GetShoppingCart(Guid personId)
        {
            return _shoppingCartService.GetShoppingCart(personId);
        }

        /// <summary>
        /// Add Product into Shopping cart
        /// </summary>
        /// <response code="204">NoContent</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">NotFound</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateShoppingCartItem(AddShoppingCartRequestDto cartRequestDto)
        {
            _shoppingCartService.SetShoppingCartItem(cartRequestDto);

            return NoContent();
        }

        /// <summary>
        /// Updates Shopping cart item by it's id.
        /// </summary>
        /// <response code="200">OK</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">NotFound</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateShoppingCartItem(Guid id, UpdateShoppingCartRequestDto cartRequestDto)
        {
            _shoppingCartService.UpdateShoppingCartItem(id, cartRequestDto);

            return Ok();
        }

        /// <summary>
        /// Deletes Shopping cart item by it's Id.
        /// </summary>
        /// <response code="204">NoContent</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">NotFound</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteShoppingCartById(Guid id)
        {
            _shoppingCartService.DeleteShoppingCartItemById(id);

            return NoContent();
        }
    }
}
