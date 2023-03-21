using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace VinylShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        /// <summary>
        /// Gets list of all genres.
        /// </summary>
        /// <returns>Genres list</returns>
        /// <response code="200">Returns genres list</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<GenreResponseDto>> GetAllGenres()
        {
            return _genreService.GetAllGenres();
        }

        /// <summary>
        /// Gets genre by it's Id.
        /// </summary>
        /// <returns>Genre</returns>
        /// <response code="200">Returns genre model</response>
        /// <response code="404">Item not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GenreResponseDto> GetGenreById(Guid id)
        {
            return _genreService.GetGenreById(id);
        }

        /// <summary>
        /// Creates new Genre.
        /// </summary>
        /// <response code="204">Successfully created new genre</response>
        /// <response code="400">If item is null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateGenre(GenreRequestDto genre)
        {
            _genreService.SetGenre(genre);
        
            return NoContent();
        }

        /// <summary>
        /// Updates Genre by it's id.
        /// </summary>
        /// <response code="200">Successfully update genre</response>
        /// <response code="400">If item is null</response>
        /// <response code="404">If item not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateGenre(Guid id, GenreRequestDto genre)
        {
            _genreService.UpdateGenre(id, genre);
         
            return Ok();
        }

        /// <summary>
        /// Deletes genre by it's Id.
        /// </summary>
        /// <response code="204">Returns nothing</response>
        /// <response code="404">Item not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteGenreById(Guid id)
        {
            _genreService.DeleteGenreById(id);
         
            return NoContent();
        }
    }
}
