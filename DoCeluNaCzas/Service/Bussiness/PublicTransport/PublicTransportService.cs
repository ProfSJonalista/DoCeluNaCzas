using System.Threading.Tasks;
using DoCeluNaCzas.Models.Bussiness;
using DoCeluNaCzas.Service.Repository;
using Newtonsoft.Json;
using DCNC.Bussiness.Models;
using System.Collections.Generic;
using System.Xml;
using DCNC.Bussiness.Model;

namespace DoCeluNaCzas.Service.Bussiness.PublicTransport
{
    public class PublicTransportService
    {
        private readonly PublicTransportRepository _publicTransportRepository;

        public PublicTransportService()
        {
            _publicTransportRepository = new PublicTransportRepository();
        }

        public async Task<BusStopDataModel> GetBusStops()
        {
            var json = await _publicTransportRepository.GetBusStops();
            var data = JsonConvert.DeserializeObject<BusStopDataModel>(json);

            return data;
        }

        public async Task<List<GroupedJoinedModel>> GetJoinedTrips()
        {
            var json = await _publicTransportRepository.GetJoinedTrips();
            var data = JsonConvert.DeserializeObject<List<GroupedJoinedModel>>(json);

            return data;
        }

        public async Task<MinuteTimeTable> GetMinutesTimeTable(string stopId, string routeId)
        {
            var json = await _publicTransportRepository.GetTimeTable(stopId, routeId);

            var data = JsonConvert.DeserializeObject<MinuteTimeTable>(json);

            return data;
        }

        public async Task<List<Route>> GetRoute(string stopId, string descStopId, bool departure, string dateTime)
        {
            var json = await _publicTransportRepository.GetRoute(stopId, descStopId, departure, dateTime);

            var data = JsonConvert.DeserializeObject<List<Route>>(json);

            return data;
        }
    }

}
