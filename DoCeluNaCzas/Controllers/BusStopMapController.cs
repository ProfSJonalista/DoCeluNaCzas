
using DCNC.Service.PublicTransportService;
using DCNC.Service.PublicTransportService.Map;
using DoCeluNaCzas.DataAccess;

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
        public object Markers { get; private set; }

        public async Task<ActionResult> BusStopMap()
        {
            var markerList = await MapService.GetMarkerList();

            return View(markerList);
        }
    }
}