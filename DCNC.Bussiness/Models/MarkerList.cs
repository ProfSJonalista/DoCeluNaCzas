
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoCeluNaCzas.Bussiness.Models
{
    public class MarkerList
    {
        public List<Marker> Markers { get; set; }

        public MarkerList()
        {
            Markers = new List<Marker>();
        }

       

    }

    public class Marker
    {
        public int StopId { get; set; }
        public string StopDesc { get; set; }
        public double StopLat { get; set; }
        public double StopLon { get; set; }
    }
}