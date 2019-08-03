using DoCeluNaCzas.Models.Bussiness.Shared;
using System;
using System.Collections.ObjectModel;

namespace DoCeluNaCzas.Models.Bussiness
{
    public class BusStopDataModel : CommonModel
    {
        public ObservableCollection<StopModel> Stops { get; set; }
    }

    public class StopModel
    {
        public int StopId { get; set; }
        public string StopDesc { get; set; }
        public double StopLat { get; set; }
        public double StopLon { get; set; }
        public string BusLineNames { get; set; }
        public string DestinationHeadsigns { get; set; }
        public bool? TicketZoneBorder { get; set; }
        public bool? OnDemand { get; set; }
        public DateTime ActivationDate { get; set; }
    }
}