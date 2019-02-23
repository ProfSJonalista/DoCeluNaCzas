using DCNC.Bussiness.Models;
using DCNC.Service.Services.Hub.Helpers;
using DoCeluNaCzas.Bussiness.Models;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DCNC.Service.Services.Hub
{
    public class HubService
    {
        HubConnection _hubConnection;
        IHubProxy _hubProxy;
        public HubService(string hubConnectionUrl, string hubName)
        {
            _hubConnection = new HubConnection(hubConnectionUrl);
            _hubProxy = _hubConnection.CreateHubProxy(hubName);
        }

        public async Task StartConnection()
        {
            await _hubConnection.Start();
        }

        public async Task<BusLineData> GetBusLineData()
        {
            return await _hubProxy.Invoke<BusLineData>(HubNames.GET_BUS_LINE_DATA);
        }

        public async Task<BusStopData> GetBusStopData()
        {
            return await _hubProxy.Invoke<BusStopData>(HubNames.GET_BUS_STOP_DATA);
        }

        public async Task<List<JoinedTripsViewModel>> GetJoinedTrips()
        {
            return await _hubProxy.Invoke<List<JoinedTripsViewModel>>(HubNames.GET_JOINED_TRIPS_MODEL_DATA);
        }
    }
}