using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DCNC.Bussiness.Models;
using DoCeluNaCzas.Models.Bussiness;
using DoCeluNaCzas.Models.ViewModels.Index;
using DoCeluNaCzas.Models.ViewModels.TimeTable;
using DoCeluNaCzas.Service.Bussiness.PublicTransport;
using DoCeluNaCzas.Service.Cashing;
using DoCeluNaCzas.Service.Cashing.Helpers;

namespace DoCeluNaCzas.Service.ViewModel
{
    public class IndexService
    {
        private readonly CacheService _cacheService;
        private readonly PublicTransportService _publicTransportService = new PublicTransportService();

        public IndexService()
        {
            _publicTransportService = new PublicTransportService();
        }

        public IndexService(CacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<MarkerModel[]> GetMarkerList()
        {
            var markerList = new MarkerListModel();

            var busStops = await _publicTransportService.GetBusStops();

            busStops.Stops.ForEach(stop => markerList.Markers.Add(MarkerMapper(stop)));

            var markersArray = markerList.Markers.ToArray();

            _cacheService.CacheData(markersArray, CacheKeys.MARKERS_BUS_STOP_DATA);

            return markersArray;
        }

        public async Task<List<GroupedJoinedModel>> GetJoinedTrips()
        {
            var trips = await _publicTransportService.GetJoinedTrips();
            return trips;
        }

    

        public async Task<List<StopModel>> GetSpotsList()
        {
            var busStops = await _publicTransportService.GetBusStops();

            return busStops.Stops;
        }



        private MarkerModel MarkerMapper(StopModel stopModel)
        {
            return new MarkerModel()
            {
                StopId = stopModel.StopId,
                StopDesc = stopModel.StopDesc,
                StopLat = stopModel.StopLat,
                StopLon = stopModel.StopLon
            };
        }


    }
}