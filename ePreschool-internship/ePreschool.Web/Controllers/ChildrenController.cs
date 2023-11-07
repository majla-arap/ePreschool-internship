using AutoMapper;
using ePreschool.Core.Dto;
using ePreschool.Service;
using ePreschool.Shared.Resources;
using ePreschool.Web.Services.ActivityLogger;
using ePreschool.Web.Services.FlashMessages;
using ePreschool.Web.Services.Toastr;
using ePreschool.Web.ViewModels.Children;
using Microsoft.AspNetCore.Mvc;

namespace ePreschool.Web.Controllers
{
    public class ChildrenController :BaseController
    {
        private readonly IChildService _childService;
        private readonly IParentService _parentService;
        private readonly IParentChildService _parentChildService;
        //private readonly IBusinessUnitService _businessUnitService;
        public ChildrenController( IChildService childService, IParentService parentService, IParentChildService parentChildService,  IActivityLogger logger, IToastr toastr, IFlashMessages flashMessages, IMapper mapper) 
            : base(logger, toastr, flashMessages, mapper)
        {
            _childService = childService;
            //_businessUnitService = businessUnitService;
            _parentService = parentService;
            _parentChildService = parentChildService;
        }

        public object LogType { get; private set; }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ChildAddViewModel childAddViewModel)
        {
            
            try
            {
                var g = Guid.NewGuid();
                childAddViewModel.Child.GUID = g.ToString();
                var mother = childAddViewModel.Mother;
                var father = childAddViewModel.Father;
                var child = childAddViewModel.Child;
                if (mother != null && father != null)
                {
                    if (mother != null)
                    {
                        var checkMother = await _parentService.GetParentByEmail(mother.Email);
                        if (checkMother.Count() == 0)
                        {
                            await _parentService.AddAsync(mother);
                        }
                    }
                    if (father != null)
                    {
                        var checkFather = await _parentService.GetParentByEmail(father.Email);
                        if (checkFather.Count() == 0)
                        {
                            await _parentService.AddAsync(father);
                        }
                    }

                    await _childService.AddAsync(child);
                    var MotherEmail = mother.Email;
                    var FatherEmail = father.Email;
                    await _parentChildService.AddChildParent(MotherEmail, childAddViewModel.Child.GUID);
                    await _parentChildService.AddChildParent(FatherEmail, childAddViewModel.Child.GUID);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Toastr.Warning("Add parent info!");
                    return View(childAddViewModel);
                }
            }
            catch (Exception e)
            {
                //await LogAsync(new LogDto(LogType.SystemError, nameof(Core.Entities.Child), null, Translations.Child, Translations.DataLoadFailure, e));
            }
            return View(childAddViewModel);
        }
    }
}
