using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DoCeluNaCzas.Bussiness.Models;
using DoCeluNaCzas.DataAccess;
using Newtonsoft.Json;

namespace DCNC.Service.PublicTransportService
{
    public class PublicTransportService
    {

        public async static Task<BusStopData> GetBusStops()
        {
            //var message = await TestHubsAsync();

            var json = await PublicTransportRepository.GetBusStops();
            
            var data = JsonConvert.DeserializeObject<BusStopData>(json);

            return data;
        }
        //DO NOT REMOVE - FOR LATER
        //private static async Task<string> TestHubsAsync()
        //{
        //    HubConnection hubConnection = new HubConnection("http://docelunaczaswebapi.com");
        //    IHubProxy hubDataProxy = hubConnection.CreateHubProxy("BusLineHub");

        //    try
        //    {
        //        await hubConnection.Start();
        //        var busLineData = await hubDataProxy.Invoke<BusLineData>("GetGeneralData");

        //        return "true";
        //    }
        //    catch (Exception e)
        //    {
        //        return "Message: " + e.Message + ", source: " + e.Source + ", inner exception" + e.InnerException + ", help link: " + e.HelpLink;
        //    }
        //}
    }

}
