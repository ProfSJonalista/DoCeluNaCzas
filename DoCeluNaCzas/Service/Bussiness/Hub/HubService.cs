using Microsoft.AspNet.SignalR.Client;
using System.Threading.Tasks;
using DoCeluNaCzas.Models.Bussiness;
using DoCeluNaCzas.Service.Bussiness.Hub.Helpers;
using System;

namespace DoCeluNaCzas.Service.Bussiness.Hub
{
    public class HubService
    {
        private  HubConnection _hubConnection;
        private  IHubProxy _hubProxy;

        public HubService(string hubConnectionUrl, string hubName)
        {
            _hubConnection = new HubConnection("http://http://docelunaczaswebapi.com/");
            _hubProxy = _hubConnection.CreateHubProxy(HubNames.DELAYS_HUB);
        }

        public async Task StartConnection()
        {
            _hubConnection = new HubConnection("http://http://docelunaczaswebapi.com/");
            _hubProxy = _hubConnection.CreateHubProxy(HubNames.DELAYS_HUB);

            _hubConnection.Start().ContinueWith(task => {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Connected");
                }

            }).Wait();
        }

        public async Task<BusStopDataModel> GetBusStopData()
        {
            return await _hubProxy.Invoke<BusStopDataModel>(HubNames.GET_BUS_STOP_DATA);
        }

        public async Task<DelayModel> GetDelays(int stopId)
        {
            return await _hubProxy.Invoke<DelayModel>(HubNames.GET_DELAYS_METHOD);
        }
    }
}