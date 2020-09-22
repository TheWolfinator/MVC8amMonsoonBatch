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

        public ActionResult GetView(int id)
        {
            return View();
        }

        public ActionResult Home()
        {
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

        public ActionResult HtmlHelperExample()
        {
            EmployeeModel obj = new EmployeeModel();
            obj.EmpName = "Abhishek Kumar";
            ViewBag.EmpList = new SelectList(db.employeeDetails, "EmpId", "EmpName");
            return View(obj);
        }


        public ActionResult Index()
        {
            var emp = (from e in db.employeeDetails
                       join
                       d in db.Departments
                       on e.DeptId
                       equals d.DeptId
                       select new empDept
                       {
                           EmpId = e.EmpId,
                           EmpName = e.EmpName,
                           EmpSalary = e.EmpSalary,
                           DepartName = d.DeptName
                       }).ToList();

            return View(emp);
        }











    }
}