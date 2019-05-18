using DoCeluNaCzas.Models.Bussiness;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Mvc;
using DoCeluNaCzas.Service.Repository;
using DCNC.Bussiness.Models;
using DoCeluNaCzas.Service.ViewModel;
using DoCeluNaCzas.Service.Cashing;
using DoCeluNaCzas.Models.ViewModels.Index;
using System.Linq;
using System.Data;
using System.Collections.Generic;

namespace DoCeluNaCzas.Controllers.TimeTable
{
    public class TimeTableController : Controller
    {
        IndexService _indexService;
        private readonly PublicTransportRepository _publicTransportRepository;
        public List<GroupedJoinedModel> joinedTripsArray = null;

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
            Option = Request["Option"].ToString();
            ViewBag.Options = Option;
            await Index();

            return View();
           
        }


    }
}