using ePreschool.Core.Dto;
using ePreschool.Shared.Resources;
using FluentValidation;

namespace ePreschool.Web.ViewModels.Cities
{
    public class CitiesAddViewModel
    {
        public CityDto City { get; set; }

        public CitiesAddViewModel()
        {
            City = new CityDto();
        }
    }

    public class CitiesAddValidator : AbstractValidator<CitiesAddViewModel>
    {
        public CitiesAddValidator()
        {
            RuleFor(x => x.City.Name)
                .NotNull().WithMessage(Translations.NameIsRequired)
                .NotEmpty().WithMessage(Translations.NameIsRequired);

            RuleFor(x => x.City.IsFavorite)
                .NotNull().WithMessage(Translations.IsFavoriteIsRequired);

            RuleFor(x => x.City.CountryId)
                    .NotNull().WithMessage(Translations.CountryIsRequired)
                    .NotEmpty().WithMessage(Translations.CountryIsRequired);


        }
    }
}
