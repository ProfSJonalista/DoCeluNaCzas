using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DoCeluNaCzas.Models.ViewModels.Index;
using DoCeluNaCzas.Service.Cashing;
using DoCeluNaCzas.Service.Repository;
using DoCeluNaCzas.Service.ViewModel;

namespace DoCeluNaCzas.Controllers
{
    public class MainPageFormController : Controller
    {

        IndexService _indexService = new IndexService(new CacheService());
        private readonly PublicTransportRepository _publicTransportRepository = new PublicTransportRepository();



        public MainPageFormController()
        {
            _publicTransportRepository = new PublicTransportRepository();
            _indexService = new IndexService(new CacheService());
        }


        // GET: MainPageFormSpots
        [HttpPost]
        public async Task<ViewResult> MainFormSearchRoute(string SpotFrom, string SpotTo, string Option, IndexModel indexModel)
        {


            Option = Request["Option"].ToString();
            SpotFrom = Request["SpotFrom"].ToString();
            SpotTo = Request["SpotTo"].ToString();
            DateTime DateTime = indexModel.FromDate;
            DateTime Time = indexModel.DateClock;

            string dateFirst = DateTime.ToString("yyyy-MM-dd").Substring(0, 10);
            string timeFirst = Time.ToString().Substring(11, 8);

            string dateTime = dateFirst + "T" + timeFirst;

            string departure = null;

            if (Option == "Departure")
            {
                departure = "true";
            }
            else
            {
                departure = "false";
            }


            var routes = await _indexService.GetRoute(SpotFrom, SpotTo, departure, dateTime);


            var routesArray = routes.ToArray();
           // ViewBag.SpotFrom = SpotFrom;
            //ViewBag.SpotTo = SpotTo;

            return View(routesArray);
        }
    }
}