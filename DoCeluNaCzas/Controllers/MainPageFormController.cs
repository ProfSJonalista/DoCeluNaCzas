using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DoCeluNaCzas.Models.ViewModels.Index;
using DoCeluNaCzas.Service.ViewModel;

namespace DoCeluNaCzas.Controllers
{
    public class MainPageFormController : Controller
    {
        // GET: MainPageForm
         [HttpPost]
          public PartialViewResult MainFormSearchRoute(MainPageForm model, string returnUrl)
          {

              string inputFrom = model.InputFrom;
              string inputTo = model.InputTo;
              var TramCheckBox = model.TramCheckBox;
              ViewBag.BusCheckBox = model.BusCheckBox;
              ViewBag.TrainCheckBox = model.TrainCheckBox;
              ViewBag.TribusCheckBox = model.TribusCheckBox;
              ViewBag.AvoidChange = model.AvoidChange;

              DateTime DateClock = model.DateClock;
              return PartialView("_MainFormSearchRouteAdditionalInfo", model);
          }

        // GET: MainPageFormSpots
        [HttpPost]
        public PartialViewResult MainFormSearchRouteSpots(SpotsListModel model, string returnUrl)
        {

            var spots = model.Spots;
            return PartialView("_MainFormSearchRouteRoutes", model);
        }


    }
}