using DCNC.Service.PublicTransportService;
using DoCeluNaCzas.Bussiness.Models;
using DoCeluNaCzas.Models.Index;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DoCeluNaCzas.Service
{
    public class IndexService
    {
        public async static Task<MarkerModel[]> GetMarkerList()
        {
            var markerList = new MarkerListModel();

            var busStops = await PublicTransportService.GetBusStops();

            busStops.Stops.ForEach(stop => markerList.Markers.Add(MarkerMapper(stop)));

            MarkerModel[] markersArray = markerList.Markers.ToArray();

            return markersArray;
        }

        private static MarkerModel MarkerMapper(Stop stop)
        {
            return new MarkerModel()
            {
                StopId = stop.StopId,
                StopDesc = stop.StopDesc,
                StopLat = stop.StopLat,
                StopLon = stop.StopLon
            };
        }
    }
}