using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models;

public class CreateDishDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }

    public int RestaurantId { get; set; }
}