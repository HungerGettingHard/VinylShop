﻿namespace Application.Models.Responses
{
    public class GenreResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Guid> ProductIds { get; set; }
    }
}
