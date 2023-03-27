using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entities;

namespace Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Genre> _genreRepository;
        private readonly IValidationService<ProductRequestDto> _validator;

        public ProductService(IUnitOfWork unitOfWork, IValidationService<ProductRequestDto> validator)
        {
            _productRepository = unitOfWork.ProductRepository;
            _genreRepository = unitOfWork.GenreRepository;
            _validator = validator;
        }

        public List<ProductResponseDto> GetAllProducts(ICollection<Guid> genreIds)
        {
            if (genreIds.Count == 0)
            {
                return _productRepository.GetList()
                    .Select(product => new ProductResponseDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        GenreIds = product.Genres
                            .Select(genre => genre.Id)
                            .ToArray()
                    })
                    .OrderBy(product => product.Name)
                    .ToList();
            }
            else
            {
                return _productRepository.GetList()
                    .Where(product => product.Genres.Any(genre => genreIds.Contains(genre.Id)))
                    .Select(product => new ProductResponseDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        GenreIds = product.Genres
                            .Select(genre => genre.Id)
                            .ToArray()
                    })
                    .OrderBy(product => product.Name)
                    .ToList();
            }
        }

        public ProductResponseDto GetProductById(Guid id)
        {
            var product = FindProductInRepositoryByIdAndThrow(id);
            var genreIds = product.Genres
                .Select(genre => genre.Id)
                .ToArray();

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                GenreIds = genreIds
            };
        }

        public void SetProduct(ProductRequestDto product)
        {
            _validator.Validate(product);

            var genres = new List<Genre>();

            foreach (var genreId in product.GenreIds)
            {
                var genre = _genreRepository.GetByID(genreId);

                if (genre == null)
                    throw new NotFoundException(nameof(Genre), genreId);

                genres.Add(genre);
            }

            _productRepository.Insert(new Product
            {
                Name = product.Name,
                Genres = genres
            });
        }

        public void DeleteProductById(Guid id)
        {
            var product = FindProductInRepositoryByIdAndThrow(id);

            _productRepository.Delete(product);
        }

        public void UpdateProduct(Guid id, ProductRequestDto productDto)
        {
            _validator.Validate(productDto);

            var product = FindProductInRepositoryByIdAndThrow(id);
            var genres = new List<Genre>();

            foreach (var genreId in productDto.GenreIds)
            {
                var genre = _genreRepository.GetByID(genreId);

                if (genre == null)
                    throw new NotFoundException(nameof(Genre), genreId);

                genres.Add(genre);
            }

            product.Name = productDto.Name;
            product.Genres = genres;

            _productRepository.SaveChanges();
        }

        private Product FindProductInRepositoryByIdAndThrow(Guid id)
        {
            var product = _productRepository.GetByID(id);

            if (product == null)
                throw new NotFoundException(nameof(Product), id);

            return product;
        }
    }
}
