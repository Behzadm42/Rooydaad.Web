using Microsoft.AspNetCore.Mvc;
using Rooydaad.Web.Models;

namespace Rooydaad.Web.Controllers
{
    public class subscribeController : Controller
    {
        
        [HttpPost]
        public IActionResult Index(SubEmail sub)
        {
            
            return Redirect($"Home/index/?message={sub.subscribeEmail} is subscribed ! ");
        }
    }
}
