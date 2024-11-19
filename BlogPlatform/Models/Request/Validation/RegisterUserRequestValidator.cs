using FluentValidation;

namespace BlogPlatform.Models.Request.Validation
{
    public class RegisterUserRequestValidator : AbstractValidator<UserRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(user => user.Email).EmailAddress().WithMessage("Neverno")
                .NotEmpty().WithMessage("pole ne mojet bit pustim");
            
        }
        
    }
}
