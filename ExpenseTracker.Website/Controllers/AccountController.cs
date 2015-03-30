using DataApp.Core;
using DataApp.Core.Controllers;
using DataApp.Core.Models;
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
        //TestModel db = new TestModel();

        // GET: Account
        public ActionResult Index()
        {
            var list = new DataAppFacade().UserController.Login("","");
            return View(list);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection data)
        {
            string username = "";
            string password = "";

            //fetch data from FormCollection
            if (data["username"] != null)
                username = (String)data["username"];
            if (data["password"] != null)
                password = (String)data["password"];

            ////fetch datails from db
            //User user = this.db.UserController.Login(username, password);
            //User user = db.Users.SingleOrDefault();

            ////Return json message if user is null
            //if(user == null)
            //    return Json("");

            //set session variables/ Authenticate
            //String authGuid = Guid.NewGuid().ToString();
            //Session.Add("authGuid", authGuid);
            //String userData = new JavaScriptSerializer().Serialize(authGuid);
            //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddMinutes(30), true, userData);
            //String encTicket = FormsAuthentication.Encrypt(authTicket);
            //HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            //Response.Cookies.Add(faCookie);

            //redirect to dashboard
            return Redirect(Url.Action("Index", "Home"));
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return Redirect(Url.Action("Index", "Home"));
        }


        public ActionResult UpdateAccountDetails()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}