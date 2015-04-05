using DataApp.Core;
using DataApp.Core.Controllers;
using DataApp.Core.DAL;
using DataApp.Core.Models;
using ExpenseTracker.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace ExpenseTracker.Website.Controllers
{
    public class AccountController : Controller
    {
        private DataAppContext db = new DataAppContext();

        // GET: Account
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM logindata)//FormCollection data)
        {
            //string username = "";
            //string password = "";

            ////fetch data from FormCollection
            //if (data["username"] != null)
            //    username = (String)data["username"];
            //if (data["password"] != null)
            //    password = (String)data["password"];
            if (ModelState.IsValid)
            {
                //fetch datails from db
                var dbFacade = new DataApp.Core.DataAppFacade();
                User user = dbFacade.UserController.Login(logindata.Username,logindata.Password);

                if (user != null) 
                {
                    FormsAuthentication.SetAuthCookie(user.Username, true);
                    //redirect to dashboard
                    return Redirect(Url.Action("Index", "Home"));                
                }
            }
            ModelState.AddModelError("", "Login data is incorrect!");
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return Redirect(Url.Action("Index", "Home"));
        }

        [Authorize]
        public ActionResult UpdateAccountDetails()
        {
            return View();
        }

        [Authorize]
        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}