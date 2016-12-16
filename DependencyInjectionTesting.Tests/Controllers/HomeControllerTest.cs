using System.ComponentModel.Composition;
using System.Web.Mvc;
using DependencyInjectionTesting.Bootstrapper;
using DependencyInjectionTesting.Controllers;
using DependencyInjectionTesting.Data.DAI;
using DependencyInjectionTesting.Data.Interfaces;
using DependencyInjectionTesting.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyInjectionTesting.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        [Import]
        private IReadOnlyRepository _repo;

        [TestInitialize]
        public void Initialize()
        {
            // Get the types for this assembly (DependencyInjectionTesting
            _repo = new CachedSqlRepository();
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(_repo);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(_repo);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Cached Sql Repository", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(_repo);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
