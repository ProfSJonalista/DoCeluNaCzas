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
            //var busStopData = (string)JsonConvert.DeserializeObject(json);
            //var json = await PublicTransportRepository.GetBusStops();
           // BusStopData busStopData = JsonConvert.DeserializeObject<BusStopData>(json);

            var json = await PublicTransportRepository.GetBusStops();
            var busStopData = (string)JsonConvert.DeserializeObject(json);
            var data = JsonConvert.DeserializeObject<BusStopData>(busStopData);


            return data;
        }


        /* public async static void GetBusLines()
         {
             var json = await PublicTransportRepository.GetBusLines();
             var busLineData = (string)JsonConvert.DeserializeObject(json);

            // var data = JsonConvert.DeserializeObject<BusLineData>(busLineData);

            // App.Current.Properties["BusLines"] = data;

             SortBusLines(busLineData);
         }

         private static void SortBusLines(BusLineData busLineData)
         {
             List<System.Web.Routing.Route> buses = busLineData.Routes.Where(x => x.AgencyId == 1
                                                     || x.AgencyId == 6
                                                     || x.AgencyId == 7
                                                     || x.AgencyId == 8
                                                     || x.AgencyId == 9
                                                     || x.AgencyId == 10
                                                     || x.AgencyId == 11
                                                     || x.AgencyId == 17
                                                     || x.AgencyId == 18).OrderBy(y => y.RouteShortName).ToList();

             List<System.Web.Routing.Route> trams = busLineData.Routes.Where(x => x.AgencyId == 2).OrderBy(y => y.RouteShortName).ToList();

             List<System.Web.Routing.Route> trolleys = busLineData.Routes.Where(x => x.AgencyId == 5).OrderBy(y => y.RouteShortName).ToList();

            // App.Current.Properties["buses"] = buses;
             //App.Current.Properties["trams"] = trams;
             //App.Current.Properties["trolleys"] = trolleys;
         }*/
    }

}
