using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Entities;

public class User
{
    public int Id { get; init; }

    [Required, MaxLength(100)]
    public string Email { get; init; } = null!;
    
    [MaxLength(100)]
    public string? FirstName { get; init; }
    
    [MaxLength(100)]
    public string? LastName { get; init; }
    
    public DateTime? DateOfBirth { get; init; }
    
    [MaxLength(100)]
    public string? Nationality { get; init; }

    [Required, MaxLength(128)]
    public string PasswordHash { get; set; } = null!;

    
    public int RoleId { get; set; }
    public virtual Role Role { get; set; } =  null!;
}