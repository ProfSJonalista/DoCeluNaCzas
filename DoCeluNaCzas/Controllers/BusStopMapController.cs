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
    public class BusStopMapController : Controller
    {
        public async Task<BusStopData> GetBusStops()
        {

            var json = await PublicTransportRepository.GetBusStops();
            var busStopData = (string)JsonConvert.DeserializeObject(json);
            var data = JsonConvert.DeserializeObject<BusStopData>(busStopData);

            return data;

        }

        public async Task<ActionResult> BusStopMap()
        {
            var busStopData = await GetBusStops();

            ViewBag.Message1 = busStopData + "YOONSEOK LIVES";

            ViewBag.Message2 = "SOPE SOPE SOPE~";

            return View(busStopData);
        }
    }
}