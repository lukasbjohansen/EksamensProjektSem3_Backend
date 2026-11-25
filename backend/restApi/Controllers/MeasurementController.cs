using Microsoft.AspNetCore.Mvc;

namespace restApi.Controllers
{
    public class MeasurementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
