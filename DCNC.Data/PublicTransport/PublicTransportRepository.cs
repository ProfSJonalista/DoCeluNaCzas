using DoCeluNaCzas.DataAccess.PublicTransport.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DoCeluNaCzas.DataAccess.PublicTransport
{
    public class PublicTransportRepository
    {
        public static async Task<string> GetBusStops()
        {
            var json = await DownloadData(Constants.BUS_STOPS);
            

            return json;
        }

        public static async Task<string> GetBusLines()
        {
            return await DownloadData(Constants.BUS_LINES);
        }

        private static async Task<string> DownloadData(string url)
        {
            var data = "";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                data = json;
            }

            return data;
        }
    }
}