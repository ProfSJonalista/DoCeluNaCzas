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

        private async Task<string> DownloadData(string url)
        {
            var data = "";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                data = json;
            }

            return data;
        }
    }
}