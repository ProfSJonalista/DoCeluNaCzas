using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoCeluNaCzas.Models.ViewModels.Index;

namespace DoCeluNaCzas.Controllers
{
    public class MainPageFormController : Controller
    {
        // GET: MainPageForm
        [HttpPost]
        public ActionResult MainFormSearchRoute(MainPageForm model, string returnUrl)
        {

            string inputFrom = model.InputFrom;
            string inputTo = model.InputTo;
            ViewBag.TramCheckBox = model.TramCheckBox;
            ViewBag.BusCheckBox = model.BusCheckBox;
            ViewBag.TrainCheckBox = model.TrainCheckBox;
            ViewBag.TribusCheckBox = model.TribusCheckBox;
            ViewBag.AvoidChange = model.AvoidChange;

            DateTime DateClock = model.DateClock;
            return View(model);
        }
    }
}