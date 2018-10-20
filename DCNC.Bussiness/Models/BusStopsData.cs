﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace DoCeluNaCzas.Bussiness.Models
{
    public class BusStopData
    {
        [JsonProperty("Day")]
        public string Day { get; set; }
        public string LastUpdate { get; set; }
        public List<Stop> Stops { get; set; }

    }

    public class Stop
    {
        public int StopId { get; set; }
        public string StopCode { get; set; }
        public string StopName { get; set; }
        public string StopShortName { get; set; }
        public string StopDesc { get; set; }
        public string SubName { get; set; }
        public string Date { get; set; }
        public double StopLat { get; set; }
        public double StopLon { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public bool VirtualBusStop { get; set; }
        public bool NonPassenger { get; set; }
        public bool Depot { get; set; }
        public bool TicketZoneBorder { get; set; }
        public bool OnDemand { get; set; }
        public string ActivationDate { get; set; }
    }
}