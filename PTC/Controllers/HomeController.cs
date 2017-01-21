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
            vm.IsValid = ModelState.IsValid;
            vm.HandleRequest();

            if (vm.IsValid)
            {
                ModelState.Clear();
            }
            else
            {
                vm.ValidationErrors.ForEach(m => ModelState.AddModelError(m.Key, m.Value));
            }

            return View(vm);
        }
    }
}