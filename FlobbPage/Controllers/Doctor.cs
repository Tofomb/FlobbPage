using Microsoft.AspNetCore.Mvc;

namespace FlobbPage.Controllers
{
    public class Doctor : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FeverCheck()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FeverCheck(double? temp = null)
        {
            if (temp == null)
                return View();
            else
            {
                ViewBag.Fever = Models.Utils.Fever((double)temp);
                return View();
            }
        }


    }
}
