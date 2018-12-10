using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoCeluNaCzas.Controllers
{
    public class MainPageFormController : Controller
    {
        // GET: MainPageForm
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(string input_from, string input_to)
        {
            return null;
        }
    }
}