namespace Application.Models.Requests
{
    public class ProductRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public decimal Price { get; set; }
        public ICollection<Guid> GenreIds { get; set; }
    }
}
