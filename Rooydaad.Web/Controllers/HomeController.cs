using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rooydaad.Web.Models;
using Rooydaad.Web.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Rooydaad.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILocationManager _locationManager;

        public HomeController(ILogger<HomeController> logger, ILocationManager locationManager)
        {
            _logger = logger;
            _locationManager = locationManager;
        }

        public IActionResult Index(string message)
        {
            ViewBag.aaaa = message;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult MyLocation()
        {
            var location=_locationManager.GetLocation();
            return View(location);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
