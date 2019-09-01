using DCNC.Bussiness.Model;
using DoCeluNaCzas.Models.ViewModels.Index;
using DoCeluNaCzas.Service.Cashing;
using DoCeluNaCzas.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DoCeluNaCzas.Controllers
{
    public class MainPageFormController : Controller
    {
        readonly IndexService _indexService;


        public MainPageFormController()
        {
            _indexService = new IndexService(new CacheService());
        }

        // GET: MainPageFormSpots
        [HttpPost]
        public async Task<ViewResult> MainFormSearchRoute(string spotFrom, string spotTo, string option, IndexModel indexModel)
        {
            var indexModelFromDate = indexModel.FromDate;
            var indexModelDateClock = indexModel.DateClock;

            var dateFirst = indexModelFromDate.ToString("yyyy-MM-dd").Substring(0, 10);
            var timeFirst = indexModelDateClock.ToString().Substring(11, 8);
            var dateTime = dateFirst + "T" + timeFirst;
            var departure = option == "Departure";

            var routes = await _indexService.GetRoute(spotFrom, spotTo, departure, dateTime) ?? new List<Route>();

            return View(routes);
        }
    }
}