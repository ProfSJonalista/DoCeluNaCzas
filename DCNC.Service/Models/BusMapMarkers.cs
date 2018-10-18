using DoCeluNaCzas.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCNC.Service.Models
{
    public class BusMapMarkers
    {

        public class MarkerList
        {

            public List<Marker> markers { get; set; }


        }

        public class Marker
        {
            public string StopId { get; set; }
            public string StopDesc { get; set; }
            public string StopLat { get; set; }
            public string StopLon { get; set; }
        }
    }
}