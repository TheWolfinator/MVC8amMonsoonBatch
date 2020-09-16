using MVC8amMonsoonBatch.Models;
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

        EmployeeEntities db = new EmployeeEntities();
        public ActionResult MyFirstMethod()
        {
            return View();
        }

        public ActionResult GetView(int id) {
            return View();
        }

        public ActionResult Home() {
            return View();
        }


        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult HtmlHelperExample() {
            EmployeeModel obj = new EmployeeModel();
            obj.EmpName = "Abhishek Kumar";
            ViewBag.EmpList = new SelectList(db.employeeDetails, "EmpId", "EmpName");
            return View(obj);
        }














    }
}