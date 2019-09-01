using System;
using System.Net.Http;
using System.Threading.Tasks;
using DoCeluNaCzas.Service.Repository.Helpers;

namespace DoCeluNaCzas.Service.Repository
{
    public class PublicTransportRepository
    {
        public async Task<string> GetBusStops()
        {
            var json = await DownloadData(Constants.BUS_STOPS);

            return json;
        }

        public async Task<string> GetJoinedTrips()
        {
            var json = await DownloadData(Constants.JOINED_TRIPS);

            return json;
        }

        public async Task<string> GetTimeTable(string stopId, string routeId)
        {
            var xml = await DownloadData(Constants.TIME_TABLES + routeId +"?stopId=" + stopId);

            return xml;
        }

        public async Task<string> GetRoute(string stopId, string destStopId, bool departure, string dateTime)
        {
            var address = (Constants.ROUTE_SEARCH + "?startStopId=" + stopId + "&destStopId=" + destStopId
                              + "&departure=" + departure + "&desiredTime=" + dateTime);

            var json = await DownloadData(address);

            return json;
        }

        async Task<string> DownloadData(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    return await client.GetStringAsync(url);
                }
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }
    }
}