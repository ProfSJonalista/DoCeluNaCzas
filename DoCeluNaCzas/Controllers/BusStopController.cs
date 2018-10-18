using DoCeluNaCzas.DataAccess;
using DoCeluNaCzas.Service.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DoCeluNaCzas.Controllers
{
    public class BusStopController : Controller
    {
        // GET: BusStop
        public async Task<BusStopData> GetBusStops()
        {

            var json = await PublicTransportRepository.GetBusStops();
            var busStopData = (string)JsonConvert.DeserializeObject(json);
            var data = JsonConvert.DeserializeObject<BusStopData>(busStopData);

            return data;

        }

        public async Task<ActionResult> BusStops()
        {
            var busStopData = await GetBusStops();

            ViewBag.Message1 = busStopData + "Worldwide handsome";

            ViewBag.Message2 = "Annyeong~";

            return View(busStopData);
        }
    }
}