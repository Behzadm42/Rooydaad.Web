using Microsoft.AspNetCore.Mvc;
using Rooydaad.Web.Models;

namespace Rooydaad.Web.Controllers
{
    [Route("events-list")]
    [Route("[controller]")]
    public class EventsController : Controller
    {
        IDatabase db;
        public EventsController(IDatabase database)
        {
            db=database;
        }
        [Route("")]
        [Route("index")]
        [Route("list")]
        public IActionResult Index()
        {
            var events = db.getallevents();
            return View(events);
        }
    }
}
