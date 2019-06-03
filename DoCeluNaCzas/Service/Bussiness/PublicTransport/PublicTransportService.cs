﻿using System.Threading.Tasks;
using DoCeluNaCzas.Models.Bussiness;
using DoCeluNaCzas.Service.Repository;
using Newtonsoft.Json;
using DCNC.Bussiness.Models;
using System.Collections.Generic;
using System.Xml;

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

        public async Task<List<GroupedJoinedModel>> GetJoinedTrips()
        {
            //var message = await TestHubsAsync();

            var json = await _publicTransportRepository.GetJoinedTrips();

            var data = JsonConvert.DeserializeObject<List<GroupedJoinedModel>>(json);

            return data;
        }

        public async Task<MinuteTimeTable> GetMinutesTimeTable(string stopId, string routeId)
        {
            var json = await _publicTransportRepository.GetTimeTable(stopId, routeId);

           // XmlDocument doc = new XmlDocument();
          //  doc.LoadXml(xml);
           // string json = JsonConvert.SerializeXmlNode(doc);

            var data = JsonConvert.DeserializeObject<MinuteTimeTable>(json);

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
