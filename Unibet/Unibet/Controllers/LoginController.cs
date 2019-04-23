﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                    HttpContext.Session.SetString("Ïd", user.Id.ToString());
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("Email", user.Email);
                    HttpContext.Session.SetString("BankBalance", user.BankBalance.ToString());

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