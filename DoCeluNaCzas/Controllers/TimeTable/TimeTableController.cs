using DCNC.Bussiness.Models;
using DoCeluNaCzas.Service.Cashing;
using DoCeluNaCzas.Service.Repository;
using DoCeluNaCzas.Service.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DoCeluNaCzas.Controllers.TimeTable
{
    public class TimeTableController : Controller
    {
        IndexService _indexService;
        private readonly PublicTransportRepository _publicTransportRepository;
        public List<GroupedJoinedModel> joinedTripsArray = null;
        string Option = null;

        public TimeTableController()
        {
            _publicTransportRepository = new PublicTransportRepository();
            _indexService = new IndexService(new CacheService());
        }



        // GET: TimeTable
        public async Task<ActionResult> Index()
        {
            joinedTripsArray = await _indexService.GetJoinedTrips();

            return View(joinedTripsArray.ToArray());
        }

        [HttpPost]
        public async Task<ActionResult> Index(string Option)
        {
            if (Request["Option"] != null)
            {
                Option = Request["Option"].ToString();
                string comType = null;
                string[] splitString = Option.Split(',');
                string lineName = splitString[0].Trim();
                string type = splitString[1].Trim();
                if (type.ToString() == "Buses")
                {
                    comType = "Autobus";
                }
                else if (type.ToString() == "Trams")
                {
                    comType = "Tramwaj";
                }
                else
                {
                    comType = "Trolejbus";
                }

                ViewBag.Options = lineName;
                ViewBag.Types = comType;

            }

            if(Request["Stop"] != null)
            {
                Option = Request["Stop"].ToString();
                string[] splitStop = Option.Split(',');
                string lineName = splitStop[0].Trim();
                string stopId = splitStop[1].Trim();
                string routId = splitStop[2].Trim();
                string destination = splitStop[3].Trim();

                ViewBag.lineName = lineName;
                ViewBag.stopId = stopId;
                ViewBag.routId = routId;
                ViewBag.destination = destination;
            }
            await Index();

            return View();

        }

    }
}