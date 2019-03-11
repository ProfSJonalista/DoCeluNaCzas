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
        // GET: MainPageFormSpots
        [HttpPost]
        public PartialViewResult MainFormSearchRouteSpots(int StopIdFrom, int StopIdTo)
        {


            /* var stopIdFrom = int.Parse(data["SelectFrom"]);
             var stopIdTo = int.Parse(data["SelectTo"]);
             var stopDescFrom = data["SelectFrom"];
             var stopDescTo = data["SelectTo"];

             model.StopIdFrom = stopIdFrom;
             model.StopIdTo = stopIdTo;
             model.StopDescFrom = stopDescFrom;
             model.StopDescTo = stopDescTo; */

            ViewData["StopIdFrom"] = StopIdFrom;
            ViewData["StopIdTo"] = StopIdTo;

            return PartialView("_MainFormSearchRouteRoutes");
        }
    }
}//TODO - zmienić partial view na view