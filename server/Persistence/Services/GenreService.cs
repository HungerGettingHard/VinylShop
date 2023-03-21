using Application.Common.Exceptions;
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
        private readonly IValidationService<GenreRequestDto> _validator;

        public GenreService(IUnitOfWork unitOfWork, IValidationService<GenreRequestDto> validator)
        {
            _repository = unitOfWork.GenreRepository;
            _validator = validator;
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

        public GenreResponseDto GetGenreById(Guid id)
        {
            var genre = FindGenreInRepositoryByIdAndThrow(id);

            return new GenreResponseDto
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public void SetGenre(GenreRequestDto genreDto)
        {
            _validator.Validate(genreDto);

            _repository.Insert(new Genre
            {
                Name = genreDto.Name,
            });
        }

        public void DeleteGenreById(Guid id)
        {
            var genre = FindGenreInRepositoryByIdAndThrow(id);

            _repository.Delete(genre);
        }

        public void UpdateGenre(Guid id, GenreRequestDto genreDto)
        {
            _validator.Validate(genreDto);
            var genre = FindGenreInRepositoryByIdAndThrow(id);            

            genre.Name = genreDto.Name;

            _repository.Update();
        }

        private Genre FindGenreInRepositoryByIdAndThrow(Guid id)
        {
            var genre = _repository.GetByID(id);

            if (genre == null)
                throw new NotFoundException(nameof(Genre), id);

            return genre;
        }
    }
}
