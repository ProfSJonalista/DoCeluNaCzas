using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DCNC.Bussiness.Models
{
    public class MinuteTimeTable
    {
        public string BusLineName { get; set; }
        public int StopId { get; set; }
        public List<int> RouteIds { get; set; }
        public Dictionary<DayType, Dictionary<int, List<int>>> MinuteDictionary { get; set; }
    }

    public enum DayType
    {
        Weekday, Saturday, Sunday
    }
}