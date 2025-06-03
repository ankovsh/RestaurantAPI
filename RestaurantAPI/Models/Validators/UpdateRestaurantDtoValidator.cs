using FluentValidation;

namespace RestaurantAPI.Models.Validators;

public class UpdateRestaurantDtoValidator  : AbstractValidator<UpdateRestaurantDto>
{
    public UpdateRestaurantDtoValidator()
    {
        RuleFor(restaurant => restaurant.Name).NotNull().NotEmpty().MaximumLength(25);
    }
}