using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCNC.Bussiness.Models
{
    public class ChooseBusStopModel
    {
        public int StopId { get; set; }
        public string StopDesc { get; set; }
        public string BusLineNames { get; set; }
        public string DestinationHeadsigns { get; set; }
    }
}