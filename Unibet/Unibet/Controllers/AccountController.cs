using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnibetBLL;
using UnibetDAL;

namespace Unibet.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserContext _personContext;

        public AccountController(IUserContext personContext)
        {
            _personContext = personContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(string username, string email, decimal amount)
        {
            var userLogic = new UserLogic(_personContext);

            int id = Convert.ToInt32(HttpContext.Session.GetInt32("Id"));

            userLogic.Edit(id, username, email, amount);
            return View();
        }
    }
}