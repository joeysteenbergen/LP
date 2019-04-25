using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unibet.Models;
using UnibetBLL;
using UnibetDAL;

namespace Unibet.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserContext _personContext;

        const string SessionId = "_Id";
        const string SessionUsername = "_Username";
        const string SessionEmail = "_Email";
        const string SessionBankBalance = "_BankBalance";

        public AccountController(IUserContext personContext)
        {
            _personContext = personContext;
        }

        public IActionResult Index()
        {
            var user = new UserViewModel();

            user.Id = HttpContext.Session.GetInt32(SessionId).GetValueOrDefault();
            user.Username = HttpContext.Session.GetString(SessionUsername);
            user.Email = HttpContext.Session.GetString(SessionEmail);
            user.BankBalance = Convert.ToDecimal(HttpContext.Session.GetString(SessionBankBalance));

            return View(user);
        }

        public IActionResult AddMoney(int amount)
        {
            var userLogic = new UserLogic(_personContext);
            int id = HttpContext.Session.GetInt32(SessionId).GetValueOrDefault();
            decimal totalAmount = Convert.ToDecimal(HttpContext.Session.GetString(SessionBankBalance)) + Convert.ToDecimal(amount);

            userLogic.AddMoney(id, totalAmount);

            HttpContext.Session.SetString(SessionBankBalance, totalAmount.ToString());

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id, string username, string email)
        {
            var userLogic = new UserLogic(_personContext);

            userLogic.Edit(id, username, email);
            return View("Index");
        }
    }
}