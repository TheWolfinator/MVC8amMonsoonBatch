using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC8amMonsoonBatch.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult MyFirstMethod()
        {
            return View();
        }
    }
}