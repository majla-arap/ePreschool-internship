using AutoMapper;
using ePreschool.Core.Dto;
using ePreschool.Core.Enumerations;
using ePreschool.Service;
using ePreschool.Shared.Resources;
using ePreschool.Web.Services.ActivityLogger;
using ePreschool.Web.Services.FileManager;
using ePreschool.Web.Services.FlashMessages;
using ePreschool.Web.Services.Toastr;
using ePreschool.Web.ViewModels.Preschools;
using Microsoft.AspNetCore.Mvc;

namespace ePreschool.Web.Controllers
{
    public class PreschoolsController : BaseController
    {
        private readonly IFileManager _fileManager;
        private readonly IPreschoolsService _preschoolsService;

        public PreschoolsController(IFileManager fileManager, IPreschoolsService preschoolsService, IActivityLogger logger, IToastr toastr, IFlashMessages flashMessages, IMapper mapper) : base(logger, toastr, flashMessages, mapper)
        {
            _fileManager = fileManager;
            _preschoolsService = preschoolsService;
        }

        public async Task<IActionResult> Index(string searchFilter = "")
        {
            var viewModel = new PreschoolsIndexViewModel();
            try
            {
                viewModel.Preschools = await _preschoolsService.GetAllAsync();
                viewModel.searchFilter = searchFilter;
            }
            catch (Exception e)
            {
                await LogAsync(new LogDto(LogType.SystemError, nameof(Core.Entities.Preschool), null, Translations.Company, Translations.DataLoadFailure, e));
            }

            return View("Index", viewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View(new PreschoolsAddViewModel());
        }



        [HttpPost]
        public async Task<IActionResult> Add(PreschoolsAddViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(viewModel);


                if (viewModel.File != null)
                {
                    viewModel.Preschool.Logo = await _fileManager.UploadFile(viewModel.File);
                    viewModel.Preschool.LogoThumbnail = await _fileManager.UploadThumbnailPhoto(viewModel.File);
                }

                await _preschoolsService.AddAsync(viewModel.Preschool);

                await LogAsync(new LogDto(LogType.Created, nameof(Core.Entities.Preschool), null, Translations.Add, Translations.ePreschool));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                await LogAsync(new LogDto(LogType.SystemError, nameof(Core.Entities.Preschool), null, Translations.Add, Translations.ePreschool, e));
                return View(viewModel);
            }

        }
    }
}