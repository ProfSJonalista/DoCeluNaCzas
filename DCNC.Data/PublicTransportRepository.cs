﻿using DoCeluNaCzas.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DoCeluNaCzas.DataAccess
{
    public class PublicTransportRepository
    {
        public async Task<string> GetBusStops()
        {
            var json = await DownloadData(Constants.BUS_STOPS);

            return json;
        }

        public async Task<string> GetBusLines()
        {
            return await DownloadData(Constants.BUS_LINES);
        }

        private async Task<string> DownloadData(string url)
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