using DoCeluNaCzas.Models.Bussiness;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Mvc;
using DoCeluNaCzas.Service.Repository;

namespace DoCeluNaCzas.Controllers
{
    public class BusStopController : Controller
    {
        private readonly PublicTransportRepository _publicTransportRepository;

        public BusStopController()
        {
            _publicTransportRepository = new PublicTransportRepository();
        }

        public async Task<ActionResult> BusStops()
        {
            var busStopData = await GetBusStops();

            ViewBag.Message1 = busStopData + "Worldwide handsome";

            ViewBag.Message2 = "Annyeong~";

            return View(busStopData);
        }

        public async Task<BusStopDataModel> GetBusStops()
        {

            var json = await _publicTransportRepository.GetBusStops();
            var busStopData = (string)JsonConvert.DeserializeObject(json);
            var data = JsonConvert.DeserializeObject<BusStopDataModel>(busStopData);

            return data;

        }
    }
}