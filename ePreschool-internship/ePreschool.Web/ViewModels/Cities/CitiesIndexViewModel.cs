using ePreschool.Core.Dto;
using ePreschool.Shared.Resources;
using FluentValidation;

namespace ePreschool.Web.ViewModels.Cities
{
    public class CitiesIndexViewModel
    {
        public string SearchValue { get; set; }
        public int CountryId { get; set; }
        public IEnumerable<CityDto> Cities { get; set; }
    }

    public class CitiesIndexValidator : AbstractValidator<CitiesIndexViewModel>
    {
        public CitiesIndexValidator()
        {
            RuleFor(x => x.SearchValue)
                .NotNull().WithMessage(Translations.NameIsRequired)
                .NotEmpty().WithMessage(Translations.NameIsRequired);
        }
    }
}
