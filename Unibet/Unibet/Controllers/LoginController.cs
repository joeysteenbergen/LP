using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnibetBLL;
using UnibetDAL;
using UnibetInterfaces;

namespace Unibet.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserContext _personContext;

        const string SessionId = "_Id";
        const string SessionUsername = "_Username";
        const string SessionEmail = "_Email";
        const string SessionBankBalance = "_BankBalance";

        public LoginController(IUserContext personContext)
        {
            _personContext = personContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UsernameLogin, string PasswordLogin)
        {
            var userLogic = new UserLogic(_personContext);

            foreach (var user in userLogic.GetAllUsers())
            {
                if(user.Username == UsernameLogin && user.Password == PasswordLogin)
                {
                    HttpContext.Session.SetInt32(SessionId, user.Id);
                    HttpContext.Session.SetString(SessionUsername, user.Username);
                    HttpContext.Session.SetString(SessionEmail, user.Email);
                    HttpContext.Session.SetString(SessionBankBalance, user.BankBalance.ToString());

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("LogOnError", "The username or password provided is incorrect.");
            return View("Index");
        }

        [HttpPost]
        public ActionResult Register(string UsernameRegister, string PasswordRegister, string EmailRegister)
        {
            var userLogic = new UserLogic(_personContext);

            userLogic.AddUser(UsernameRegister, PasswordRegister, EmailRegister);
            return RedirectToAction("Index", "Home");
        }
    }
}