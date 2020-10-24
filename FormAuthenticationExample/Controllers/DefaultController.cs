using FormAuthenticationExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormAuthenticationExample.Controllers
{
    [Authorize]
    public class DefaultController : Controller
    {
        // GET: Default
        
        public ActionResult Index()
        {
           
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login() {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(UserModel uobj)
         {
            if (uobj.UserName=="srinivas" && uobj.UserName == "srinivas") {
                FormsAuthentication.SetAuthCookie(uobj.UserName, false);
                Session["UserName"] = uobj.UserName;
                return Redirect("~/Default/Index");
            }
            else
            {
                ViewBag.msg = "Invalid Login Details";
                return View();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}