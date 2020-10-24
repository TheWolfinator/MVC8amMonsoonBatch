using MyFirstWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstWebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult GetData()
        {
            

            return View();
        }

        public JsonResult GetData2()
        {
            List<EmployeeModel> listobj = new List<EmployeeModel>();
            EmployeeModel obj = new EmployeeModel();
            obj.EmpId = 1;
            obj.EmpName = "Suraj";
            obj.EmpSalary = 27000;


            EmployeeModel obj1 = new EmployeeModel();
            obj1.EmpId = 2;
            obj1.EmpName = "Abhisek";
            obj1.EmpSalary = 5699;

            EmployeeModel obj2 = new EmployeeModel();
            obj2.EmpId = 3;
            obj2.EmpName = "Rambabu";
            obj2.EmpSalary = 6540;

            listobj.Add(obj);
            listobj.Add(obj1);
            listobj.Add(obj2);


            return Json(listobj,JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAngularView()
        {

            return View();
        }
    }
}
