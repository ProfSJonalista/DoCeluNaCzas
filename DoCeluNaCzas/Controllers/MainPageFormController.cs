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
        public ViewResult MainFormSearchRoute(string SpotFrom, string SpotTo, string Option, IndexModel indexModel)
        {


            Option = Request["Option"].ToString();
            SpotFrom = Request["SpotFrom"].ToString();
            SpotTo = Request["SpotTo"].ToString();
            DateTime DateTime = indexModel.FromDate;
            DateTime Time = indexModel.DateClock;

            ViewBag.Options = Option;
            ViewBag.SpotFrom = SpotFrom;
            ViewBag.SpotTo = SpotTo;
            ViewBag.Date = DateTime.ToString().Substring(0,10);
            ViewBag.Time = Time.ToString().Substring(11,8);



            return View();
        }
    }
}