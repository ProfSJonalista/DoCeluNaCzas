using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoCeluNaCzas.Controllers;
using System.Web.Mvc;
using System.Threading.Tasks;
using DoCeluNaCzas.Service.ViewModel;
using DoCeluNaCzas.Service.Cashing;
using DoCeluNaCzas.Service.Repository;
using DoCeluNaCzas.Models.ViewModels.Index;
using System.Linq;

namespace DCNC.Tests
{
    [TestClass]
    public class MainPageFormControllerTest
    {
        static IndexModel indygo;
        IndexService _indexService = new IndexService(new CacheService());
        private readonly PublicTransportRepository _publicTransportRepository = new PublicTransportRepository();

        
        public MainPageFormControllerTest()
        {
            indygo = new IndexModel() { FromDate = DateTime.Parse("201-08-16T00:00:00"), DateClock = DateTime.Parse("201-08-16T09:00:00") };
        }



        [TestMethod]
       // [DataRow("221", "2025", "Departure", indygo)]
        public async Task MainFormSearchRoute(string SpotFrom, string SpotTo, string Option, IndexModel indexModel)
        {
            MainPageFormController controller = new MainPageFormController();
            var result = controller.MainFormSearchRoute("221", "2025", "Departure", indygo);
            Assert.IsNotNull(result);
        }
    }
}
