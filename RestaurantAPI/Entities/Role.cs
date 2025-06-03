using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Entities;

public class Role
{
    public int Id { get; set; }
    
    [Required, MaxLength(25)]
    public string Name { get; init; } = null!;
}