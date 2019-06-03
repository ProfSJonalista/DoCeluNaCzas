using System;
using System.Collections.Generic;
using DoCeluNaCzas.Models.Bussiness.Shared;

namespace DoCeluNaCzas.Models.Bussiness
{
    public class BusStopDataModel : CommonModel
    {
        public List<StopModel> Stops { get; set; }
    }

    public class StopModel
    {
        public int StopId { get; set; }
        public string StopDesc { get; set; }
        public double StopLat { get; set; }
        public double StopLon { get; set; }
        public bool? TicketZoneBorder { get; set; }
        public bool? OnDemand { get; set; }
        public DateTime ActivationDate { get; set; }
    }
}