using Microsoft.AspNetCore.Mvc;

namespace Rooydaad.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        [BindProperty]
        public string MyProperty { get; set; }
        [HttpGet]
        public IActionResult login()
        {
            return View(new Models.LoginModel());
        } 
        [HttpPost]
        public IActionResult login(Models.LoginModel loginModel)
        {
            string s = MyProperty;
            if (this.ModelState.IsValid)
            {
                ViewData["Message"] = "Yor'e loged in";
                return View();
            }
            ViewData["Message"] = "Yor'e Fucked out";
            return View();

        }
    }
}
