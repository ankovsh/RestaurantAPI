using FluentValidation;

namespace RestaurantAPI.Models.Validators;

public class CreateDishDtoValidator: AbstractValidator<CreateDishDto>
{
    public CreateDishDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(25);

        RuleFor(x => x.Description)
            .MaximumLength(100);
    }
}