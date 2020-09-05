using AdoNetExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoNetExample.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        EmployeeContext db = new EmployeeContext();

        public ActionResult Index()
        {
             
            return View(db.GetEmployee());
        }

        [HttpGet]//Action verb
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel empobj)
        {
            //int i = db.save(EmpName, EmpSalary);
            int i = db.saveEmployee(empobj);
            if (i > 0) {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}