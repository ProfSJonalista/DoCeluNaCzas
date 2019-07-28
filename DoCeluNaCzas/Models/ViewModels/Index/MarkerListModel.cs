using System.Collections.Generic;

namespace DoCeluNaCzas.Models.ViewModels.Index
{
    public class MarkerListModel
    {
        public List<MarkerModel> Markers { get; set; }

        public MarkerListModel()
        {
            Markers = new List<MarkerModel>();
        }

    }

  

    public class MarkerModel
    {
        internal string DestinationHeadsigns;

        public int StopId { get; set; }
        public string StopDesc { get; set; }
        public double StopLat { get; set; }
        public double StopLon { get; set; }

        public string StopBusLines { get; set; }
        public string StopHeading { get; set; }
    }
}