using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DCNC.Bussiness.Models;
using DoCeluNaCzas.Models.Bussiness;
using DoCeluNaCzas.Models.ViewModels.Index;
using DoCeluNaCzas.Service.Bussiness.PublicTransport;
using DoCeluNaCzas.Service.Cashing;
using DoCeluNaCzas.Service.Cashing.Helpers;

namespace DoCeluNaCzas.Service.ViewModel
{
    public class IndexService
    {
        readonly CacheService _cacheService;
        readonly PublicTransportService _publicTransportService = new PublicTransportService();

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

            foreach (var stop in busStops.Stops)
            {
                markerList.Markers.Add(MarkerMapper(stop));
            }

            var markersArray = markerList.Markers.ToArray();

            _cacheService.CacheData(markersArray, CacheKeys.MARKERS_BUS_STOP_DATA);

            return markersArray;
        }

        public async Task<List<GroupedJoinedModel>> GetJoinedTrips()
        {
            var trips = await _publicTransportService.GetJoinedTrips();
            return trips;
        }

        public async Task<MinuteTimeTable> GetTimeTables(string stopId, string routeId)
        {
            var tables = await _publicTransportService.GetMinutesTimeTable(stopId, routeId);
            return tables;
        }


        public async Task<List<Route>> GetRoute(string stopId, string descStopId, string departure, string dateTime)
        {
            var routes = await _publicTransportService.GetRoute(stopId, descStopId, departure, dateTime);
            return routes;
        }


        public async Task<ObservableCollection<StopModel>> GetSpotsList()
        {
            var busStops = await _publicTransportService.GetBusStops();
            return busStops.Stops;
        }

        public async Task<ObservableCollection<StopModel>> GetBusStopModels()
        {
            var busStopDataModel = await _publicTransportService.GetBusStops();
            return busStopDataModel.Stops;
        }

        static MarkerModel MarkerMapper(StopModel stopModel)
        {
            return new MarkerModel()
            {
                StopId = stopModel.StopId,
                StopDesc = stopModel.StopDesc,
                StopLat = stopModel.StopLat,
                StopLon = stopModel.StopLon,
                StopBusLines = stopModel.BusLineNames,
                StopHeading = stopModel.DestinationHeadsigns
            };
        }
    }
}