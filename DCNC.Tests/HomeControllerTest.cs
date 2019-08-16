using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DoCeluNaCzas.Controllers;
using System.Web.Mvc;
using System.Threading.Tasks;
using DoCeluNaCzas.Service.ViewModel;
using DoCeluNaCzas.Service.Cashing;

namespace DCNC.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        IndexService _indexService = new IndexService(new CacheService());

        [TestMethod]
        public async Task Index()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            var result = controller.Index() as Task<ActionResult>;
            var markers = _indexService.GetMarkerList();
            var spotsArray = await _indexService.GetSpotsList();
            var chosenBusStops = await _indexService.GetBusStopModels();
            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(markers);
            Assert.IsNotNull(spotsArray);
            Assert.IsNotNull(chosenBusStops);

            

        }
    }
}
