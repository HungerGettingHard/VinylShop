using Application.Models.Requests;
using Application.Models.Responses;

namespace Application.Interfaces
{
    /// <summary>
    /// CRUD service for genres
    /// </summary>
    public interface IGenreService
    {
        public List<GenreResponseDto> GetAllGenres();

        public GenreResponseDto GetGenreById(int id);

        public void SetGenre(GenreRequestDto genreDto);

        public void DeleteGenreById(int id);

        public void UpdateGenre(GenreRequestDto genre);
    }
}
