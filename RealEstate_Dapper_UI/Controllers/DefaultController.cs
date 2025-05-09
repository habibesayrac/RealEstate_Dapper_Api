using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<PartialViewResult> PartialSearch()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialSearch(string p, int z, string y)
        {
            TempData["word"] = p;
            TempData["word1"] = y;
            TempData["word5"] = z;

            return RedirectToAction("PropertyListWithSearch", "Property");
        }
    }
}
