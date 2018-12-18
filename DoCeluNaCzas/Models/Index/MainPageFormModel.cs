﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoCeluNaCzas.Models.Index
{
    public class MainPageForm
    {
        public string InputFrom { get; set; }
        public string InputTo { get; set; }
        public bool TramCheckBox { get; set; }
        public bool BusCheckBox { get; set; }
        public bool TrainCheckBox { get; set; }
        public bool TribusCheckBox { get; set; }
        public bool AvoidChange { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateClock{ get; set; }
        
    }

}