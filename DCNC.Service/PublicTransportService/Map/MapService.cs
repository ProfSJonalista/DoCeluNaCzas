
using DoCeluNaCzas.Bussiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DCNC.Service.PublicTransportService.Map
{
    public class MapService
    {
        public async static Task<Marker[]> GetMarkerList()
        {
            var markerList = new MarkerList();

            var busStops = await PublicTransportService.GetBusStops();

            busStops.Stops.ForEach(stop => markerList.Markers.Add(MarkerMapper(stop)));

            Marker[] markersArray = markerList.Markers.ToArray();

            return markersArray;
        }

        private static Marker MarkerMapper(Stop stop)
        {
            return new Marker()
            {
                StopId = stop.StopId,
                StopDesc = stop.StopDesc,
                StopLat = stop.StopLat,
                StopLon = stop.StopLon
            };
        }
    }
}