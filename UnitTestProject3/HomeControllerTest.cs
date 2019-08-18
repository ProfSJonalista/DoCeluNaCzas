using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoCeluNaCzas.Controllers;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace UnitTestProject3
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            Task<ActionResult> result = controller.Index() as Task<ActionResult>;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
