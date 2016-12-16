using System.ComponentModel.Composition;
using System.Web.Mvc;
using DependencyInjectionTesting.Data.Interfaces;
using Microsoft.Practices.Unity;

namespace DependencyInjectionTesting.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : Controller
    {

        private IReadOnlyRepository _repo;

        [ImportingConstructor]
        public HomeController([Import("Cached")][Dependency("Cached")]IReadOnlyRepository repo)
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