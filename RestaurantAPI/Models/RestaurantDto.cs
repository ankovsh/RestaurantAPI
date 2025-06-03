namespace RestaurantAPI.Models;

public class RestaurantDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public string? Description { get; init; }
    public string Category { get; init; } = null!;
    public bool HasDelivery { get; init; }
    public string City { get; init; } = null!;
    public string Street { get; init; } =  null!;
    public string PostalCode { get; init; } = null!;

    public List<DishDto> Dishes { get; init; } = new List<DishDto>();
}