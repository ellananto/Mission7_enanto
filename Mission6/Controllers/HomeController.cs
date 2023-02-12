using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private MovieCollectionContext blahContext { get; set; }

        public HomeController(MovieCollectionContext someName)
        {
            blahContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = blahContext.Category.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult MovieForm(MovieFormResponse ar)
        {
            if (ModelState.IsValid)
            {
                blahContext.Add(ar);
                blahContext.SaveChanges();
                return View("Confirmation", ar);
            }
            else //if invalid, send them right back to the view with their responses populated 
            {
                ViewBag.Categories = blahContext.Category.ToList();
                return View();
            }
        }
        public IActionResult MovieList ()
        {
            var applications = blahContext.responses
                .Include(x => x.Category)
                .ToList();
            return View(applications);
        }
        [HttpGet]
        public IActionResult Edit (int rentalid)
        {
            ViewBag.Categories = blahContext.Category.ToList();
            var rental = blahContext.responses.Single(x => x.RentalID == rentalid);
            return View( "MovieForm", rental);
        }
        [HttpPost]
        public IActionResult Edit (MovieFormResponse ar)
        {
                blahContext.Update(ar);
                blahContext.SaveChanges();
                return RedirectToAction("MovieList");     

        }
        [HttpGet]
        public IActionResult Delete (int rentalid)
        {
            var rental = blahContext.responses.Single(x => x.RentalID == rentalid);
            return View(rental);
        }
        [HttpPost]
        public IActionResult Delete (MovieFormResponse ar)
        {
            blahContext.responses.Remove(ar);
            blahContext.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
