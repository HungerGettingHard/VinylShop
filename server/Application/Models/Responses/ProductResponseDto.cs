namespace Application.Models.Responses
{
    public class ProductResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Guid> GenreIds { get; set; }
    }
}
