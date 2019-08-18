using System;
using DoCeluNaCzas.Service.Cashing;
using DoCeluNaCzas.Service.Repository;
using DoCeluNaCzas.Service.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoCeluNaCzas.Controllers;
using System.Threading.Tasks;
using System.Linq;
using DoCeluNaCzas.Controllers.TimeTable;
using System.Web.Mvc;

namespace DCNC.Tests
{
    [TestClass]
    public class TimeTableControllerTest
    {
        IndexService _indexService = new IndexService(new CacheService());
        private readonly PublicTransportRepository _publicTransportRepository = new PublicTransportRepository();

        [TestMethod]
        public async Task Index()
        {
            TimeTableController controller = new TimeTableController();
            var result = controller.Index() as Task<ActionResult>;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DataRow("11", "2215")]
        public async Task TimeTable(string stopId, string routeId)
        {
            TimeTableController controller = new TimeTableController();
            var result = controller.TimeTable("11", "2215") as Task<ActionResult>;

            Assert.IsNotNull(result);
            

        }
    }
}
