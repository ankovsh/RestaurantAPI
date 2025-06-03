using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Entities
{
    public class Restaurant
    {
        public int Id { get; init; }

        [Required, MaxLength(25)] 
        public string Name { get; set; } = null!;
    
        [MaxLength(100)]
        public string? Description { get; set; }
        
        [MaxLength(25)]
        public string Category { get; init; }  = null!;
        public bool HasDelivery { get; set; }
        
        [MaxLength(100)]
        public string ContactEmail { get; init; }  = null!;
        
        [MaxLength(25)]
        public string ContactNumber { get; init; } = null!;

        public int AddressId { get; init; }
        public virtual Address Address { get; init; } = null!;

        public virtual List<Dish> Dishes { get; init; }  = null!;
    }
}
