

using ePreschool.Shared.Resources;

using FluentValidation;

namespace ePreschool.Web.ViewModels
{
    public class AccessSignInViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class AccessSignInValidator : AbstractValidator<AccessSignInViewModel>
    {
        public AccessSignInValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull().WithMessage(Translations.UsernameIsRequired)
                .NotEmpty().WithMessage(Translations.UsernameIsRequired);

            RuleFor(x => x.Password)
                .NotNull().WithMessage(Translations.PasswordIsRequired)
                .NotEmpty().WithMessage(Translations.PasswordIsRequired);
        }
    }
}
