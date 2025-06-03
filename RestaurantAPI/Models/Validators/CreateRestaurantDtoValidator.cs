using FluentValidation;

namespace RestaurantAPI.Models.Validators;

public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
{
    public CreateRestaurantDtoValidator()
    {
        RuleFor(restaurant => restaurant.Name).NotNull().NotEmpty().MaximumLength(25);
        
        RuleFor(restaurant => restaurant.Description).MaximumLength(100);
        
        RuleFor(restaurant => restaurant.Category).MaximumLength(25);
        
        RuleFor(restaurant => restaurant.City).NotEmpty().MaximumLength(25);
        
        RuleFor(restaurant => restaurant.Street).NotEmpty().MaximumLength(25);
        
        RuleFor(restaurant => restaurant.PostalCode).NotEmpty().MaximumLength(25);
        
        RuleFor(restaurant => restaurant.ContactEmail).MaximumLength(100);
        
        RuleFor(restaurant => restaurant.ContactNumber).MaximumLength(25);
    }
}