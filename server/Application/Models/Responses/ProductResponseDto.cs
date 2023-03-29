namespace Application.Models.Responses
{
    public class ProductResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<ProductGenreResponseDto> Genres { get; set; }
    }

    public class ProductGenreResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
