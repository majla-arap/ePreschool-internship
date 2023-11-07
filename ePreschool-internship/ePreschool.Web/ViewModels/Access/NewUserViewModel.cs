using ePreschool.Core;
using ePreschool.Core.Dto;
using ePreschool.Shared.Resources;
using FluentValidation;

namespace ePreschool.Web.ViewModels
{
    public class NewUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int? CityId { get; set; }
        public CityDto City { get; set; }

        public string Password { get; set; }
        public string PasswordConfirm { get; set; }

        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }

        public string UsernName { get; set; }
        public string Email { get; set; }


        public int? PreschoolId { get; set; }
        public PreschoolDto Preschool { get; set; }
        public int? CurrentBusinessUnitId { get; set; }
        public BusinessUnitDto CurrentBusinessUnit { get; set; }
    }
    public class NewUserValidator : AbstractValidator<NewUserViewModel>
    {
        public NewUserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull().WithMessage(Translations.FirstNameRequired)
                .NotEmpty().WithMessage(Translations.FirstNameRequired);

            RuleFor(x => x.LastName)
                    .NotNull().WithMessage(Translations.LastNameIsRequired)
                    .NotEmpty().WithMessage(Translations.LastNameIsRequired);

            RuleFor(x => x.Address)
                .NotNull().WithMessage(Translations.AddressIsRequired)
                .NotEmpty().WithMessage(Translations.AddressIsRequired);

            RuleFor(x => x.Gender)
                    .NotNull().WithMessage(Translations.GenderRequired)
                    .NotEmpty().WithMessage(Translations.GenderRequired);

            RuleFor(x => x.CityId)
               .NotNull().WithMessage(Translations.CityRequired)
               .NotEmpty().WithMessage(Translations.CityRequired);

            RuleFor(x => x.PreschoolId)
                    .NotNull().WithMessage(Translations.PreschoolRequired)
                    .NotEmpty().WithMessage(Translations.PreschoolRequired);

            RuleFor(x => x.UsernName)
                .NotNull().WithMessage(Translations.UsernameIsRequired)
                .NotEmpty().WithMessage(Translations.UsernameIsRequired);

            RuleFor(x => x.Email)
                    .NotNull().WithMessage(Translations.EmailIsRequired)
                    .NotEmpty().WithMessage(Translations.EmailIsRequired);

            RuleFor(x => x.CurrentBusinessUnitId)
                    .NotNull().WithMessage(Translations.BusinessUnitRequired)
                    .NotEmpty().WithMessage(Translations.BusinessUnitRequired);

            RuleFor(x => x.Password)
                .NotNull().WithMessage(Translations.PasswordIsRequired)
                .NotEmpty().WithMessage(Translations.PasswordIsRequired)
                .MinimumLength(6).WithMessage(Translations.PasswordLength6)
                .Matches("[a-z]").WithMessage(Translations.PasswordRequiresLower)
                .Matches("[A-Z]").WithMessage(Translations.PasswordRequiresUpper)
                .Matches("[0-9]").WithMessage(Translations.PasswordRequiresDigit);

            RuleFor(x => x.PasswordConfirm)
                .NotNull().WithMessage(Translations.PasswordIsRequired)
                .NotEmpty().WithMessage(Translations.PasswordIsRequired)
                .Equal(x => x.Password).WithMessage(Translations.PasswordsMatch);
        }
    }
}
