using DCNC.Bussiness.Models;
using DoCeluNaCzas.Models.Bussiness;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DoCeluNaCzas.Models.ViewModels.Index
{
    public class IndexModel
    {
        public MarkerModel[] MarkerArrayIndex { get; set; }
        public MainPageForm MainPageFormIndex { get; set; }
        public ObservableCollection<StopModel> SpotsListIndex { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateClock { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FromDate { get; set; }

    }
}