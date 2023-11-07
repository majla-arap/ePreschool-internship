using AutoMapper;
using ePreschool.Core.Dto;
using ePreschool.Core.Enumerations;
using ePreschool.Service;
using ePreschool.Shared.Resources;
using ePreschool.Web.Services.ActivityLogger;
using ePreschool.Web.Services.FlashMessages;
using ePreschool.Web.Services.Toastr;
using ePreschool.Web.ViewModels;
using ePreschool.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ePreschool.Web.Controllers
{
    public class WorkingProgramsController : BaseController
    {
        private readonly IWorkingProgramService _workingProgramService;
        public WorkingProgramsController(IWorkingProgramService workingProgramService, IActivityLogger logger, IToastr toastr, IFlashMessages flashMessages, IMapper mapper) : base(logger, toastr, flashMessages, mapper)
        {
            _workingProgramService = workingProgramService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new WorkingProgramIndexViewModel();
            try
            {
                viewModel.WorkingPrograms = await _workingProgramService.GetAllWithoutDeleted();
            }
            catch (Exception e)
            {
                await LogAsync(new LogDto(LogType.SystemError, nameof(Core.Entities.Preschool), null, Translations.WorkingProgram, Translations.DataLoadFailure, e));
            }

            return View("Index", viewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Add(WorkingProgramAddViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(viewModel);

                await _workingProgramService.AddAsync(viewModel.WorkingProgram);

                await LogAsync(new LogDto(LogType.Created, nameof(Core.Entities.WorkingProgram), null, Translations.Add, Translations.WorkingProgram));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                await LogAsync(new LogDto(LogType.SystemError, nameof(Core.Entities.WorkingProgram), null, Translations.Add, Translations.WorkingProgram, e));
                return View(viewModel);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var workingProgram = await _workingProgramService.GetByIdAsync(id);
            var viewModel = new WorkingProgramAddViewModel
            {
                WorkingProgram = workingProgram
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WorkingProgramAddViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            try
            {
                await _workingProgramService.Update(viewModel.WorkingProgram);
            }
            catch (Exception e)
            {
                await LogAsync(new LogDto(LogType.SystemError, nameof(Core.Entities.WorkingProgram), null, Translations.Add, Translations.WorkingProgramAddFailure, e));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _workingProgramService.RemoveByIdAsync(id);
                await LogAsync(new LogDto(LogType.Deleted, nameof(Core.Entities.WorkingProgram), id, Translations.Delete, Translations.WorkingProgramDeleteSuccess));
            }
            catch (Exception e)
            {
                await LogAsync(new LogDto(LogType.SystemError, nameof(Core.Entities.WorkingProgram), null, Translations.Delete, Translations.WorkingProgramDeleteFailure, e));
            }

            return Ok();
        }
    }
}
