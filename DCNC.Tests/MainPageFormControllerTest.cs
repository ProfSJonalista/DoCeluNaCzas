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



        [TestMethod]

        public async Task MainFormSearchRoute()
        {
            MainPageFormController controller = new MainPageFormController();
            var result = controller.MainFormSearchRoute("221", "2025", "Departure", new IndexModel()
            {
                FromDate = new DateTime(2019,08,16),
                DateClock = new DateTime(2019,08,16,9,0,0)
            });
            Assert.IsNotNull(result);
        }
    }
}
