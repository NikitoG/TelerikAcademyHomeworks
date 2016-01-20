using MvcSumator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSumator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? firstNumber, int? secondNumber)
        {
            ViewBag.FirstNumber = firstNumber;
            ViewBag.SecondNumber = secondNumber;
            ViewBag.Sum = firstNumber + secondNumber;
            return this.View();
        }

        [HttpPost]
        public ActionResult Sum(int? firstNumber, int? secondNumber)
        {
            return this.RedirectToAction("Index", new { firstNumber, secondNumber});
        }
    }
}