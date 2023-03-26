namespace Application.Models.Requests
{
    public class ProductRequestDto
    {
        public string Name { get; set; }
        public ICollection<Guid> GenreIds { get; set; }
    }
}
