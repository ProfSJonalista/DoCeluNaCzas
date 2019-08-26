using DCNC.Bussiness.Models;
using DoCeluNaCzas.Service.Cashing;
using DoCeluNaCzas.Service.Repository;
using DoCeluNaCzas.Service.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Windows.Forms;
using System;
using System.Web.Routing;

namespace DoCeluNaCzas.Controllers.TimeTable
{
    public class TimeTableController : Controller
    {
        IndexService _indexService;
        private readonly PublicTransportRepository _publicTransportRepository;
        public List<GroupedJoinedModel> joinedTripsArray = null;
        string Option = null;
        string param = null;
        public MinuteTimeTable minuteTimeTable = null;
        object x = null;

        public TimeTableController()
        {
            _publicTransportRepository = new PublicTransportRepository();
            _indexService = new IndexService(new CacheService());
        }



        // GET: TimeTable
        public async Task<ActionResult> Index()
        {
            joinedTripsArray = await _indexService.GetJoinedTrips();

            return View(joinedTripsArray.ToArray());
        }

        [HttpPost]
        public async Task<ActionResult> Index(string Option)
        {


            if (Request["Option"] != null)
            {
                
                Option = Request["Option"].ToString();
                string comType = null;
                string[] splitString = Option.Split(',');
                string lineName = splitString[0].Trim();
                string type = splitString[1].Trim();
                if (type.ToString() == "Buses")
                {
                    comType = "AUTOBUS";
                }
                else if (type.ToString() == "Trams")
                {
                    comType = "TRAMWAJ";
                }
                else
                {
                    comType = "TROLEJBUS";
                }

                TempData["TestVal"] = "";
                TempData["TestVal"] = Request["Option"].ToString();
                ViewBag.Param = param;
                ViewBag.Options = lineName;
                ViewBag.Types = comType;
                await Index();

            }
            else
            {
                if (TempData["TestVal"] != null)
                {
                    //MessageBox.Show(TempData["TestVal"].ToString());
                    Option = TempData["TestVal"].ToString();
                    string comType = null;
                    string[] splitString = Option.Split(',');
                    string lineName = splitString[0].Trim();
                    string type = splitString[1].Trim();
                    if (type.ToString() == "Buses")
                    {
                        comType = "AUTOBUS";
                    }
                    else if (type.ToString() == "Trams")
                    {
                        comType = "TRAMWAJ";
                    }
                    else
                    {
                        comType = "TROLEJBUS";
                    }

                    
                    ViewBag.Options = lineName;
                    ViewBag.Types = comType;
                    await Index();
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
                
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> TimeTable(string Option)
        {

            if (Request["Stop"] != null)
            {
                Option = Request["Stop"].ToString();
                string[] splitStop = Option.Split(',');
                string lineName = splitStop[0].Trim();
                string stopId = splitStop[1].Trim();
                string routId = splitStop[2].Trim();
                string destination = splitStop[3].Trim();
                string stop = splitStop[4].Trim();

                //ViewBag.lineName = lineName;
                //ViewBag.stopId = stopId;
                //ViewBag.routId = routId;
                //ViewBag.destination = destination;

                await TimeTable(stopId, routId, stop, destination);

            }

            else
            {
                //MessageBox.Show(TempData["TestVal"].ToString());
                return await Index(TempData["TestVal"].ToString());

               // var routeValues = new RouteValueDictionary
               // {
                //    {"Option", TempData["TestVal"].ToString() }
                //};

                //return RedirectToAction(nameof(Index), routeValues);
            }


            return View();

        }

        public async Task<ActionResult> TimeTable(string stopId, string routeId, string stop, string destination)
        {
            minuteTimeTable = await _indexService.GetTimeTables(stopId, routeId);
            ViewBag.stopId = stopId;
            ViewBag.routeIds = minuteTimeTable.RouteIds;
            ViewBag.minDic = minuteTimeTable.MinuteDictionary;
            ViewBag.busLine = minuteTimeTable.BusLineName;
            ViewBag.stop = stop;
            ViewBag.destination = destination;
            

            return View(minuteTimeTable);
        }

    }
}