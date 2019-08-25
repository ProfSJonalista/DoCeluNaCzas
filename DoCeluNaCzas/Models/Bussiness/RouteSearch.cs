﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCNC.Bussiness.Model
{
    public class Route
    {
        public TimeSpan FullTimeOfTravel { get; set; }
        public string Buses { get; set; }
        public StopChange FirstStop { get; set; }
        public StopChange LastStop { get; set; }
        public List<Change> ChangeList { get; set; }
    }

    public class Change
    {
        public string BusLineName { get; set; }
        public int RouteId { get; set; }
        public int TripId { get; set; }
        public int ChangeNo { get; set; }
        public TimeSpan TimeOfTravel { get; set; }
        public StopChange FirstStop { get; set; }
        public StopChange LastStop { get; set; }
        public List<StopChange> StopChangeList { get; set; }
    }

    public class StopChange
    {
        public string Name { get; set; }
        public int RouteId { get; set; }
        public int TripId { get; set; }
        public int StopId { get; set; }
        public double StopLat { get; set; }
        public double StopLon { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime EstimatedTime { get; set; }
        public int StopSequence { get; set; }
        public bool MainTrip { get; set; }
        public bool? OnDemand { get; set; }
    }
}
