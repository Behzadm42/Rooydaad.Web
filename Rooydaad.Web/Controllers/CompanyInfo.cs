using Microsoft.AspNetCore.Mvc;

namespace Rooydaad.Web.Controllers
{
    [Route("company")]
    public class CompanyInfoController : Controller
    {
        [Route("~/")]
        [Route("privacy")]
        public IActionResult privacy()
        {
            return View();
        }
        public IActionResult termsOfServices()
        {
            return View();
        }

    }
}
