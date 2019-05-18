using DoCeluNaCzas.Models.Bussiness;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Mvc;
using DoCeluNaCzas.Service.Repository;
using DCNC.Bussiness.Models;
using DoCeluNaCzas.Service.ViewModel;
using DoCeluNaCzas.Service.Cashing;
using DoCeluNaCzas.Models.ViewModels.Index;
using DoCeluNaCzas.Models.ViewModels.TimeTable;
using System.Linq;
using System.Data;

namespace DoCeluNaCzas.Controllers.TimeTable
{
    public class TimeTableController : Controller
    {
        IndexService _indexService;
        private readonly PublicTransportRepository _publicTransportRepository;

        public TimeTableController()
        {
            _publicTransportRepository = new PublicTransportRepository();
            _indexService = new IndexService(new CacheService());
        }

 

        // GET: TimeTable
        public async Task<ActionResult> Index()
        {
            var joinedTripsArray = await _indexService.GetJoinedTrips();
            
            return View(joinedTripsArray.ToArray());
        }

        [HttpPost]
        public ActionResult ChosenLine(string Option)
        {
            string line = Option;

            return(null);
           
        }


    }
}