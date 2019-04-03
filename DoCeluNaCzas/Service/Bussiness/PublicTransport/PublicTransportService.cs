﻿using System.Threading.Tasks;
using DoCeluNaCzas.Models.Bussiness;
using DoCeluNaCzas.Service.Repository;
using Newtonsoft.Json;
using DCNC.Bussiness.Models;

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
            //var message = await TestHubsAsync();

            var json = await _publicTransportRepository.GetBusStops();
            
            var data = JsonConvert.DeserializeObject<BusStopDataModel>(json);

            return data;
        }

        public async Task<JoinedTripsViewModel> GetJoinedTrips()
        {
            //var message = await TestHubsAsync();

            var json = await _publicTransportRepository.GetJoinedTrips();

            var data = JsonConvert.DeserializeObject<JoinedTripsViewModel>(json);

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
