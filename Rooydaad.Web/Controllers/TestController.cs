using Microsoft.AspNetCore.Mvc;

namespace Rooydaad.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index(int id,string name)
        {
            return Content("Just for test :)");
        }
    }
}
