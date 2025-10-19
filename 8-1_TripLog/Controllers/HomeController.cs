/*
 Virginia Villalobos
 COP4813.0M1
 HomeController.cs

 This page defines some of the default actions provided by Visual Studios
 I added a refresh action that removes all but the seeded data to lessen clutter as tests are conducted
  
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _8_1_TripLog.Models;
using Microsoft.EntityFrameworkCore;

namespace _8_1_TripLog.Controllers
{
    public class HomeController : Controller
    {
        //References DB for viewbag to use
        private TripContext context { get; set; }
        public HomeController(TripContext ctx)
        {
            context = ctx;
        }

        private readonly ILogger<HomeController> _logger;


        public IActionResult Index()
        {
            var trips = context.Trips.OrderBy(
            m => m.Destination).ToList();
            return View(trips);
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

        [HttpPost]
        public IActionResult Refresh()
        {
            var extra = context.Trips.Where(t => t.TripId != 1).ToList();            
            context.Trips.RemoveRange(extra);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
