using System.ComponentModel.Composition;
using System.Web.Mvc;
using DependencyInjectionTesting.Data.Interfaces;
using DependencyInjectionTesting.Models;

namespace DependencyInjectionTesting.Controllers
{
    public class HomeController : Controller
    {
        [Import]
        // [Import("Cached")]
        private IReadOnlyRepository _repo;

        public HomeController()
        {
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        public HomeController(IReadOnlyRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = _repo.Get();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}