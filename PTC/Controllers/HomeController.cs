using PTC.Data;
using System.Web.Mvc;

namespace PTC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var vm = new TrainingProductViewModel();

            vm.HandleRequest();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(TrainingProductViewModel vm)
        {
            vm.HandleRequest();

            ModelState.Clear();

            return View(vm);
        }
    }
}