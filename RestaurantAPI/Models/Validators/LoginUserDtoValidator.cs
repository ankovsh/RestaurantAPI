using FluentValidation;
using RestaurantAPI.Entities;

namespace RestaurantAPI.Models.Validators;

public class LoginUserDtoValidator: AbstractValidator<LoginUserDto>
{
    public LoginUserDtoValidator(RestaurantDbContext dbContext)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .Custom((value, context) =>
            {
                var email = dbContext.Users.FirstOrDefault(u => u.Email == value);
                if (email is null)
                {
                    context.AddFailure("Email", "Invalid Email");
                }
            });;

        RuleFor(x => x.Password)
            .MinimumLength(6);
    }
}