using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalculator.Models;

namespace WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(BitViewModels model)
        {
            model.GetInitValues();

            return View(model);
        }
    }
}