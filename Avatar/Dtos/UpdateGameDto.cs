using System.ComponentModel.DataAnnotations;

namespace Avatar.Dtos
{
    public record UpdateGameDto
    {
        [Required] 
        public string Name { get; init; }

        [Required] 
        [Range(1, 1000)] 
        public decimal Price { get; init; }
    }
}