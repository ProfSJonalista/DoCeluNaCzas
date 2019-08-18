using DoCeluNaCzas.Models.ViewModels.Index;
using DoCeluNaCzas.Service.Cashing;
using DoCeluNaCzas.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DoCeluNaCzas.Controllers
{
    public class HomeController : Controller
    {
        IndexService _indexService;

        public HomeController()
        {
            _indexService = new IndexService(new CacheService());
        }
        
        public async Task<ActionResult> Index()
        {
            var markerArray = await _indexService.GetMarkerList();
            var spotsArray = await _indexService.GetSpotsList();
            var chosenBusStops = await _indexService.GetBusStopModels();

            var listStopsFrom = new List<SelectListItem>(
                from e in chosenBusStops
                select new SelectListItem
                {
                    Selected = true,
                    Text = Convert.ToString(e.StopDesc + " (" + e.BusLineNames + ")" + " -> " + e.DestinationHeadsigns),
                    Value = Convert.ToString(e.StopId)
                });

            var sortedListFrom = listStopsFrom.OrderBy(x => x.Text).ToList();

            ViewBag.SpotsListIndex = new SelectList(sortedListFrom, "Value", "Text");
 

            var indexModel = new IndexModel()
            {
                MainPageFormIndex = new MainPageForm(),
                MarkerArrayIndex = markerArray,
                SpotsListIndex = spotsArray
            };

            return View(indexModel);      
        }

    }
}