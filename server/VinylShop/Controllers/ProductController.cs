using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Persistence.Services;

namespace VinylShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Gets list of all products.
        /// </summary>
        /// <returns>Product list</returns>
        /// <response code="200">OK</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<List<ProductResponseDto>> GetAllProducts([FromQuery] ICollection<Guid> genreIds)
        {
            return _productService.GetAllProducts(genreIds);
        }

        /// <summary>
        /// Gets Product by it's Id.
        /// </summary>
        /// <returns>Product</returns>
        /// <response code="200">OK</response>
        /// <response code="404">NotFound</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductResponseDto> GetProductById(Guid id)
        {
            return _productService.GetProductById(id);
        }

        /// <summary>
        /// Creates new product
        /// </summary>
        /// <response code="200">OK</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Unauthorized</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateProduct(ProductRequestDto product)
        {
            _productService.SetProduct(product);

            return NoContent();
        }

        /// <summary>
        /// Updates Product by it's id.
        /// </summary>
        /// <response code="200">OK</response>
        /// <response code="400">BadRequest</response>
        /// <response code="404">NotFound</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateProduct(Guid id, ProductRequestDto product)
        {
            _productService.UpdateProduct(id, product);

            return Ok();
        }

        /// <summary>
        /// Deletes Product by it's Id.
        /// </summary>
        /// <response code="204">NoContent</response>
        /// <response code="404">NotFound</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteProductById(Guid id)
        {
            _productService.DeleteProductById(id);

            return NoContent();
        }
    }
}
