﻿using Application.Interfaces;
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
        /// Gets list of all Genres.
        /// </summary>
        /// <returns>Genres list</returns>
        /// <response code="200">OK</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<GenreResponseDto>> GetAllGenres()
        {
            return _genreService.GetAllGenres();
        }

        /// <summary>
        /// Gets Genre by it's Id.
        /// </summary>
        /// <returns>Genre</returns>
        /// <response code="200">OK</response>
        /// <response code="404">NotFound</response>
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
        /// <response code="204">NoContent</response>
        /// <response code="400">BadRequest</response>
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
        /// <response code="200">OK</response>
        /// <response code="400">BadRequest</response>
        /// <response code="404">NotFound</response>
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
        /// Deletes Genre by it's Id.
        /// </summary>
        /// <response code="204">NoContent</response>
        /// <response code="404">NotFound</response>
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
