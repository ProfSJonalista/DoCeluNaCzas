﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DCNC.Service.PublicTransportService;
using DCNC.Service.PublicTransportService.Map;
using DoCeluNaCzas.DataAccess;
using DoCeluNaCzas.Models.Index;
using DoCeluNaCzas.Service;
using Newtonsoft.Json;

namespace DoCeluNaCzas.Controllers
{
    public class HomeController : Controller
    {
        public object Markers { get; private set; }

        
        public async Task<ActionResult> Index()
        {
            var markerArray = await IndexService.GetMarkerList();

            var indexModel = new IndexModel()
            {
                MainPageFormIndex = new MainPageForm(),
                MarkerArrayIndex = markerArray
            };

            return View(indexModel);
        }

        public ActionResult About()
        {
            
         
            ViewBag.Message = "Your application description page. JUST WOOOOOOOOOOOOOOOORK";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /* public ActionResult BusStops()
         {
             BusStopData busStopData = new BusStopData();

             busStopData = GetBusStops();

             //BusStopData busStop = new BusStopData();
             ViewBag.Message1 = busStopData + "Worldwide handsome";

             ViewBag.Message2 = "Annyeong~";
             return View();
         }*/





    }
}