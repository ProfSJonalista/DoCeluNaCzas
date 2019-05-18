using DCNC.Bussiness.Models;
using DoCeluNaCzas.Models.Bussiness;
using System;
using System.Collections.Generic;

namespace DoCeluNaCzas.Models.ViewModels.Index
{
    public class IndexModel
    {
        public MarkerModel[] MarkerArrayIndex { get; set; }
        public MainPageForm MainPageFormIndex { get; set; }
        public List<StopModel> SpotsListIndex { get; set; }
    

    }
}//TODO - wsadzic te modele do jednej klasy - tej