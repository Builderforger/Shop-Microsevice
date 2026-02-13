using System.ComponentModel.DataAnnotations;

namespace BasketApi.DTOs
{
    public class BasketItemCreateDto
    {
        public required string ProductId { get; init; }
        [Range(1,1000, ErrorMessage = "Кол-во товаро должно быть больше 0")]
        public int Quantity { get; init; }
    }
}
