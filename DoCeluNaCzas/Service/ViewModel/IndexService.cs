using System.Threading.Tasks;
using DoCeluNaCzas.Models.Bussiness;
using DoCeluNaCzas.Models.ViewModels.Index;
using DoCeluNaCzas.Service.Bussiness.PublicTransport;

namespace DoCeluNaCzas.Service.ViewModel
{
    public class IndexService
    {
        private readonly PublicTransportService _publicTransportService;

        public IndexService()
        {
            _publicTransportService = new PublicTransportService();
        }

        public async Task<MarkerModel[]> GetMarkerList()
        {
            var markerList = new MarkerListModel();

            var busStops = await _publicTransportService.GetBusStops();

            busStops.Stops.ForEach(stop => markerList.Markers.Add(MarkerMapper(stop)));

            var markersArray = markerList.Markers.ToArray();

            return markersArray;
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