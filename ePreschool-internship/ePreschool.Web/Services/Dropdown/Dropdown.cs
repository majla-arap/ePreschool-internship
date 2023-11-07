using ePreschool.Core.Dto;
using ePreschool.Service;
using ePreschool.Shared.Resources;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace ePreschool.Web.Services.Dropdown
{
    public interface IDropdown
    {
        Task<List<SelectListItem>> Countries(bool includeEmptyItem = true);
        Task<List<SelectListItem>> Cities(bool includeEmptyItem = true);
        Task<List<SelectListItem>> BusinessUnits(bool includeEmptyItem = true);
        Task<List<SelectListItem>> Preschools(bool includeEmptyItem = true);
        Task<List<SelectListItem>> WorkingPrograms(bool includeEmptyItem = true);

        
    }
    public class Dropdown : IDropdown
    {
        private readonly ICitiesService _cityService;
        private readonly ICountiresService _countiresService;
        private readonly IPreschoolsService _preschoolsService;
        private readonly IBusinessUnitService _businessUnitService;
        private readonly IWorkingProgramService _workingProgramService;


        public Dropdown(ICitiesService cityService, ICountiresService countiresService, IWorkingProgramService workingProgramService, IPreschoolsService preschoolsService, IBusinessUnitService businessUnitService)
        {
            _cityService = cityService;
            _countiresService = countiresService;
            _preschoolsService = preschoolsService;
            _businessUnitService = businessUnitService;
            _workingProgramService = workingProgramService;
        }
        public async Task<List<SelectListItem>> WorkingPrograms(bool includeEmptyItem = true)
        {
            return GenerateSelectList(await _workingProgramService.GetSelectListAsync(), includeEmptyItem);
        }

        public async Task<List<SelectListItem>> BusinessUnits(bool includeEmptyItem = true)
        {
            return GenerateSelectList(await _businessUnitService.GetSelectListAsync(), includeEmptyItem);
        }
        public async Task<List<SelectListItem>> Cities(bool includeEmptyItem = true)
        {
            return GenerateSelectList(await _cityService.GetSelectListAsync(), includeEmptyItem);
        }

        public async Task<List<SelectListItem>> Countries(bool includeEmptyItem = true)
        {
            return GenerateSelectList(await _countiresService.GetSelectListAsync(), includeEmptyItem);
        }
        public async Task<List<SelectListItem>> Preschools(bool includeEmptyItem = true)
        {
            return GenerateSelectList(await _preschoolsService.GetSelectListAsync(), includeEmptyItem);
        }

        private List<SelectListItem> GenerateSelectList(IEnumerable<EntityItemDto> source, bool includeEmptyItem = false)
        {
            var selectListItems = source.Select(s => new SelectListItem(s.Label, s.Id.ToString())).ToList();
            if (includeEmptyItem)
                selectListItems.Insert(0, new SelectListItem(Translations.Choose, null));

            return selectListItems;
        }
    }
}
