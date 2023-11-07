using Microsoft.AspNetCore.Mvc;

namespace ePreschool.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("error/{id?}")]
        public IActionResult Index(int ? id)
        {
            return View(id);
        }
    }
}
