using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlobbPage.Controllers
{
    public class GamePlaceController : Controller
    {
       /* public IActionResult Index()
        {
            return View();
        }*/

        [HttpGet]
        public IActionResult GuessingGame()
        {
            Random random = new Random();
            
            int r = random.Next(1, 101);
            //Session
            HttpContext.Session.SetInt32("hiddenNumb", r);
            
            

            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(int guess)
        {
            var h = HttpContext.Session.GetInt32("hiddenNumb");

            int toHigh = 0;
            if(guess > h)
            {
                toHigh = 1;
            }
            else if(guess < h){
                toHigh = 2;
            }
            else if(guess == h)
            {
                toHigh = 3;
            }

            ViewBag.toHigh = toHigh;

            return View();
        }
    }
}
