using ePreschool.Core;
using ePreschool.Core.Dto;
using ePreschool.Service;
using ePreschool.Shared.Services.Crypto;
using ePreschool.Web.Attributes;
using ePreschool.Web.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace ePreschool.Web.Controllers
{

    [Authenticate]
    public class HomeController : Controller
    {
        private readonly ICrypto _crypto;
        private readonly IUsersService _userService;
        private readonly IPreschoolsService _cityService;

        public HomeController(ICrypto crypto, IUsersService userService, IPreschoolsService cityService)
        {
            _crypto = crypto;
            _userService = userService;
            _cityService = cityService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetAllAsync();
            return View(user);
        }
        public async Task<IActionResult> AddUser()
        {
            var rand = new Random().Next();
            var salt = _crypto.GenerateSalt();
            var newUser = await _userService.AddAsync(new ApplicationUserDto() { 
                FirstName = $"First_{rand}", 
                LastName = $"Last_{rand}", 
                Gender = Gender.Male, 
                //PasswordHash = _crypto.GenerateHash("test",salt), 
                //PasswordSalt = salt, 
                UsernName = $"user{rand}@preschool.ba",
                 PasswordHash = "/jgjzf1nC8YDuZMV5q0kYrRqIarjCDgWjBERaZiyyO0=",
                PasswordSalt = "DFQVcTkMv8qWjq/5ars8Eg==",
            });
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}