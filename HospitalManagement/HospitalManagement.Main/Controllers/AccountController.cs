using HospitalManagement.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Main.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if(login.LoginBy == "Doctor")
            {

            }
            else
            {

            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterSubmit()
        {
            return View();
        }
        public void Logout()
        {
            Response.Redirect("/Account/login");
        }
    }
}