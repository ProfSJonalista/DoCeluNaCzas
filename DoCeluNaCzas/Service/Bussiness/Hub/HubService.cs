using Microsoft.AspNet.SignalR.Client;
using System.Threading.Tasks;
using DoCeluNaCzas.Models.Bussiness;
using DoCeluNaCzas.Service.Bussiness.Hub.Helpers;

namespace DoCeluNaCzas.Service.Bussiness.Hub
{
    public class HubService
    {
        private readonly HubConnection _hubConnection;
        private readonly IHubProxy _hubProxy;

        public HubService(string hubConnectionUrl, string hubName)
        {
            _hubConnection = new HubConnection(hubConnectionUrl);
            _hubProxy = _hubConnection.CreateHubProxy(hubName);
        }

        public async Task StartConnection()
        {
            await _hubConnection.Start();
        }

        public async Task<BusStopDataModel> GetBusStopData()
        {
            return await _hubProxy.Invoke<BusStopDataModel>(HubNames.GET_BUS_STOP_DATA);
        }
    }
}