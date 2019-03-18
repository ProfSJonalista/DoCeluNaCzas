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
        public ViewResult MainFormSearchRoute(string SpotFrom, string SpotTo, string Option, TimeSpan Time)
        {


            Option = Request["Option"].ToString();
            SpotFrom = Request["SpotFrom"].ToString();
            SpotTo = Request["SpotTo"].ToString();
            Time = TimeSpan.Parse( Request["Time"]);


            ViewBag.Options = Option;
            ViewBag.SpotFrom = SpotFrom;
            ViewBag.SpotTo = SpotTo;
            ViewBag.Time = Time.ToString();





            return View();
        }
    }
}