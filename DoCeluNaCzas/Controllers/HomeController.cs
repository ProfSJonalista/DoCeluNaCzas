using DoCeluNaCzas.Service;
using System.Threading.Tasks;
using System.Web.Mvc;
using DoCeluNaCzas.Models.ViewModels.Index;
using DoCeluNaCzas.Service.ViewModel;

namespace DoCeluNaCzas.Controllers
{
    public class HomeController : Controller
    {
        IndexService _indexService;

        public HomeController()
        {
            _indexService = new IndexService();
        }
        
        public async Task<ActionResult> Index()
        {
            var markerArray = await _indexService.GetMarkerList();

            var indexModel = new IndexModel()
            {
                MainPageFormIndex = new MainPageForm(),
                MarkerArrayIndex = markerArray
            };

            return View(indexModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page. JUST WOOOOOOOOOOOOOOOORK";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Timetable()
        {
            
            return View();
        }

        public ActionResult Delays()
        {
            ViewBag.Message = "Your delays page.";

            return View();
        }

        /* public ActionResult BusStops()
         {
             BusStopData busStopData = new BusStopData();

             busStopData = GetBusStops();

             //BusStopData busStop = new BusStopData();
             ViewBag.Message1 = busStopData + "Worldwide handsome";

             ViewBag.Message2 = "Annyeong~";
             return View();
         }*/
    }
}