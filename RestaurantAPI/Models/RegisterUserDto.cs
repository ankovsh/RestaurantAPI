using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models;

public class RegisterUserDto
{
    public string Email { get; set; }  = null!;
    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Nationality { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public int RoleId { get; set; }
}