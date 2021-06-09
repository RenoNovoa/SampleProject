using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleProject.Models;
using SampleProject.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGoogleService _googleService;

        public HomeController(IGoogleService googleService)
        {
            _googleService = googleService;
        }

        public IActionResult Index()
        {
            var results = _googleService.GetPlacesAsync("8675309");

            return View();
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
