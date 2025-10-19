/*
 Virginia Villalobos
 COP4813.0M1
 TripController.cs

 This page defines the actions that move the user through the process
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _8_1_TripLog.Models;

namespace _8_1_TripLog.Controllers
{
    public class TripController : Controller
    {
        //References DB for viewbag to use
        private TripContext context { get; set; }
        public TripController(TripContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var trips = context.Trips.OrderBy(
            m => m.Destination).ToList();
            return View(trips);
        }

        /*public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Add", new Trip());
        }*/

        //FIRST INPUT
        [HttpGet]
        public IActionResult In1() => View(new Trip());
        [HttpPost]
        public IActionResult In1(Trip model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // redisplay form with errors
            }

            TempData["Destination"] = model.Destination;
            TempData["StartDate"] = model.StartDate;
            TempData["EndDate"] = model.EndDate;
            TempData["Accomodations"] = model.Accomodation;

            TempData.Keep();
            return string.IsNullOrEmpty(model.Accomodation) ? RedirectToAction("In3") : RedirectToAction("In2");
        }

        //SECOND INPUT
        [HttpGet]
        public IActionResult In2()
        {
            ViewBag.Accommodations = TempData["Accomodations"];
            TempData.Keep();
            return View();
        }
        [HttpPost]
        public IActionResult In2(string AccomodationEmail, string AccomodationPhone)
        {
            TempData["AccomodationEmail"] = AccomodationEmail;
            TempData["AccomodationPhone"] = AccomodationPhone;
            TempData.Keep();


            return RedirectToAction("In3");
        }

        //THIRD INPUT
        [HttpGet]
        public IActionResult In3()
        {
            ViewBag.Destination = TempData["Destination"];
            TempData.Keep();
            return View();
        }
        [HttpPost]
        public IActionResult In3(string ThingsToDo1, string ThingsToDo2, string ThingsToDo3)
        {
            var dest = TempData["Destination"]?.ToString();
            var trip = new Trip
            {
                Destination = dest,
                StartDate = DateTime.Parse(TempData["StartDate"]?.ToString()),
                EndDate = DateTime.Parse(TempData["EndDate"]?.ToString()),
                Accomodation = TempData["Accomodations"]?.ToString(),
                AccomodationEmail = TempData["AccomEmail"]?.ToString(),
                AccomodationPhone = TempData["AccomPhone"]?.ToString(),
                ThingsToDo1 = ThingsToDo1,
                ThingsToDo2 = ThingsToDo2,
                ThingsToDo3 = ThingsToDo3
            };

            context.Trips.Add(trip);
            context.SaveChanges();

            TempData.Clear();
            TempData["Message"] = "Trip to " +  dest + " Added Successfully";

            return RedirectToAction("Index","Home");
        }

        //CANCEL & CLEAR LOGIC
        [HttpPost]
        public IActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}