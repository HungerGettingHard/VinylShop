using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
            try
            {
                return _genreService.GetAllGenres();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
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
        public ActionResult<GenreResponseDto> GetGenreById(int id)
        {
            try
            {
                return _genreService.GetGenreById(id);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
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
            try
            {
                _genreService.SetGenre(genre);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Updates Genre.
        /// </summary>
        /// <response code="200">Successfully update genre</response>
        /// <response code="400">If item is null</response>
        /// <response code="404">If item not found</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateGenre(GenreRequestDto genre)
        {
            try
            {
                _genreService.UpdateGenre(genre);
                return Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Deletes genre by it's Id.
        /// </summary>
        /// <response code="204">Returns nothing</response>
        /// <response code="404">Item not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteGenreById(int id)
        {
            try
            {
                _genreService.DeleteGenreById(id);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
