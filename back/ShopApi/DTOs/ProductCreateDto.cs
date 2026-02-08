using Microsoft.OpenApi;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShopApi.DTOs
{
    public class ProductCreateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public required string Name { get; init; }
        [StringLength(1000, MinimumLength = 10)]
        public string? Description { get; init; }
        [Required]
        public int CategoryId { get; init; }
        [Range(0.01, 1000000)]
        [DefaultValue(100.0)]
        public decimal Price { get; init; }
        [Range(0, 10000)]
        [DefaultValue(10)]
        public int Stock { get; init; }
    }
}
