using Application.Models.Requests;
using Application.Models.Responses;

namespace Application.Interfaces
{
    /// <summary>
    /// CRUD service for products
    /// </summary>
    public interface IProductService
    {
        public List<ProductResponseDto> GetAllProducts(ICollection<Guid> genreIds);

        public ProductResponseDto GetProductById(Guid id);

        public void SetProduct(ProductRequestDto product);

        public void DeleteProductById(Guid id);

        public void UpdateProduct(Guid id, ProductRequestDto productDto);
    }
}
