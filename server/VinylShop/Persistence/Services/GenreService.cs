using Application.Common.Interfaces;
using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entities;

namespace Persistence.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenericRepository<Genre> _repository;

        public GenreService(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.GenreRepository;
        }

        public List<GenreResponseDto> GetAllGenres()
        {
            return _repository.GetList()
                .Select(genre => new GenreResponseDto
                {
                    Id = genre.Id,
                    Name = genre.Name
                })
                .OrderBy(genre => genre.Name)
                .ToList();
        }

        public GenreResponseDto GetGenreById(int id)
        {
            var genre = _repository.GetByID(id);
            return new GenreResponseDto
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public void SetGenre(GenreRequestDto genreDto)
        {
            _repository.Insert(new Genre
            {
                Name = genreDto.Name,
            });
        }

        public void DeleteGenreById(int id)
        {
            _repository.Delete(id);
        }

        public void UpdateGenre(GenreRequestDto genre)
        {
            _repository.Update(new Genre
            {
                Name = genre.Name
            });
        }
    }
}
