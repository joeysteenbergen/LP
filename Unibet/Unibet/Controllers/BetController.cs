using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Unibet.Controllers
{
    public class BetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult MakeBet(string[] games, string[] winners, int totalOdd, int betMoney)
        {
            return View();
        }
    }
}