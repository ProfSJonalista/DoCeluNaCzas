using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoCeluNaCzas.Models.Index;

namespace DoCeluNaCzas.Controllers
{
    public class MainPageFormController : Controller
    {
        // GET: MainPageForm
        [HttpPost]
        public ActionResult MainFormSearchRoute(MainPageForm model, string returnUrl)
        {

            string inputFrom = model.InputFrom;

            return View(model);
        }
    }
}