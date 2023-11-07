using AutoMapper;
using ePreschool.Core.Dto;
using ePreschool.Core.Enumerations;
using ePreschool.Service;
using ePreschool.Shared.Resources;
using ePreschool.Web.Attributes;
using ePreschool.Web.Services.ActivityLogger;
using ePreschool.Web.Services.FlashMessages;
using ePreschool.Web.Services.Toastr;
using ePreschool.Web.ViewModels.Cities;
using Microsoft.AspNetCore.Mvc;

namespace ePreschool.Web.Controllers
{
    [MenuItem(MenuItem.Cities)]
    public class CitiesController : BaseController
    {
        private readonly ICitiesService _citiesService;

        public CitiesController(ICitiesService citiesService, IActivityLogger logger, IToastr toastr, IFlashMessages flashMessages, IMapper mapper) : base(logger, toastr, flashMessages, mapper)
        {
            _citiesService = citiesService;
        }

        public async Task<IActionResult> Index(string searchValue = "", int countryId = 0)
        {
            var viewModel = new CitiesIndexViewModel();
            try
            {
                viewModel.Cities = await _citiesService.GetByParametersAsync(searchValue, countryId);
                viewModel.SearchValue = searchValue;

            }
            catch (Exception e)
            {
                await LogAsync(new LogDto(LogType.SystemError, nameof(Core.Entities.City), null, Translations.Cities, Translations.DataLoadFailure, e));
            }
            return View(viewModel);
        }

        public IActionResult Add()
        {         
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CitiesAddViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            try
            {
                await _citiesService.AddAsync(viewModel.City);
                await LogAsync(new LogDto(LogType.Created, nameof(Core.Entities.City), null, Translations.Add, Translations.CityAddSuccess));
            }
            catch (Exception e)
            {
                await LogAsync(new LogDto(LogType.SystemError, nameof(Core.Entities.City), null, Translations.Add, Translations.CityAddFailure, e));
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var city = await _citiesService.GetByIdAsync(id);
            var viewModel = new CitiesAddViewModel
            {
                City = city
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CitiesAddViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            try
            {
                await _citiesService.Update(viewModel.City);
            }
            catch (Exception e)
            {
                await LogAsync(new LogDto(LogType.SystemError, nameof(Core.Entities.City), null, Translations.Add, Translations.CityAddFailure, e));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _citiesService.RemoveByIdAsync(id);
                await LogAsync(new LogDto(LogType.Deleted, nameof(Core.Entities.City), id, Translations.Delete, Translations.CityDeleteSuccess));
            }
            catch (Exception e)
            {
                await LogAsync(new LogDto(LogType.SystemError, nameof(Core.Entities.City), null, Translations.Delete, Translations.CityDeleteFailure, e));
            }

            return Ok();
        }

    }
}
