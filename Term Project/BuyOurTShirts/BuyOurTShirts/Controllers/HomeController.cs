﻿using Microsoft.AspNetCore.Mvc;

namespace BuyOurTShirts.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Booking()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}