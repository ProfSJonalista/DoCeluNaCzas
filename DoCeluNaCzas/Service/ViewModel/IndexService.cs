﻿using System.Threading.Tasks;
using DoCeluNaCzas.Models.Bussiness;
using DoCeluNaCzas.Models.ViewModels.Index;
using DoCeluNaCzas.Service.Bussiness.PublicTransport;
using DoCeluNaCzas.Service.Cashing;
using DoCeluNaCzas.Service.Cashing.Helpers;

namespace DoCeluNaCzas.Service.ViewModel
{
    public class IndexService
    {
        private readonly CacheService _cacheService;
        private readonly PublicTransportService _publicTransportService;

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

        public async Task<SearchRouteFieldsModel[]> GetSpotsList()
        {
            var stopsList = new SpotsListModel();
            var busStops = await _publicTransportService.GetBusStops();
            busStops.Stops.ForEach(stop => stopsList.Spots.Add(StopsMapper(stop)));

            var stopsArray = stopsList.Spots.ToArray();

            return stopsArray;
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

        private SearchRouteFieldsModel StopsMapper(StopModel stopModel)
        {
            return new SearchRouteFieldsModel()
            {
                StopId = stopModel.StopId,
                StopDesc = stopModel.StopDesc
            };
        }

    }
}