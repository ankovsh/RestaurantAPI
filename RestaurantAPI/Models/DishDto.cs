namespace RestaurantAPI.Models;

public class DishDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public string Description { get; init; } = null!;
    public decimal Price { get; init; }
}