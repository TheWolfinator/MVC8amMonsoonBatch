using AdminEcom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminEcom.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private EcomerceEntities1 db = new EcomerceEntities1();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Login(Login model)
        {
            if (model.Email=="Admin@SmartShop.com" && model.Password=="Admin")
            {
                Session["UserName"] = "Admin";
                return RedirectToAction("Index", "Categories");
            }
            else
            {
                ModelState.AddModelError("", "EmailId or Password Incorrect.");
            }
            return View(model);
        }
    }
}