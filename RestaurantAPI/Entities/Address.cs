using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Entities
{
    public class Address
    {
        public int Id { get; set; }
        
        [Required, MaxLength(50)]
        public string City { get; init; } = null!;
        
        [Required, MaxLength(50)]
        public string Street { get; init; }  = null!;
        
        [Required, MaxLength(25)]
        public string PostalCode { get; init; } = null!;

        public virtual Restaurant Restaurant { get; set; }  = null!;
    }
}
