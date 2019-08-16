using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoCeluNaCzas.Controllers;
using System.Web.Mvc;
using DoCeluNaCzas.Service.Repository;

namespace DCNC.Tests
{
    [TestClass]
    public class BusStopControllerTest
    {
        private readonly PublicTransportRepository _publicTransportRepository = new PublicTransportRepository();

        [TestMethod]
        public async Task BusStops()
        {
            BusStopController controller = new BusStopController();
            
            Assert.IsNotNull(controller.GetBusStops());
        }

        [TestMethod]
        public async Task GetBusStops()
        {
            var data = await _publicTransportRepository.GetBusStops();

            Assert.IsNotNull(data);
        }
    }
}
