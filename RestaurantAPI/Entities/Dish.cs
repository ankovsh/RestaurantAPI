using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Entities
{
    public class Dish
    {
        public int Id { get; init; }
        
        [Required, MaxLength(25)]
        public string Name { get; init; } = null!;
        
        [MaxLength(100)]
        public string? Description { get; init; }
        public decimal Price { get; init; }

        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; init; } =  null!;
    }
}
