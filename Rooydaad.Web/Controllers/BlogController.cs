using Microsoft.AspNetCore.Mvc;

namespace Rooydaad.Web.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Author()
        {
            return Content("Hello Viewers");
        }
    }
}
