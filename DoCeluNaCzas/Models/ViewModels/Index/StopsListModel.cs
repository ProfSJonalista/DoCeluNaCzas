using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoCeluNaCzas.Models.ViewModels.Index
{
    public class SpotsListModel
    {
        public List<SearchRouteFieldsModel> Spots { get; set; }

        public SpotsListModel()
        {
            Spots = new List<SearchRouteFieldsModel>();
        }

    }

    public class SearchRouteFieldsModel
    {
        public int StopId { get; set; }
        public string StopDesc { get; set; }
    }
}