using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models;

public class CreateRestaurantDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Category { get; set; } = null!;
    public bool HasDelivery { get; set; }
    public string ContactEmail { get; set; } = null!;
    public string ContactNumber { get; set; } = null!;
    
    public string City { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
}