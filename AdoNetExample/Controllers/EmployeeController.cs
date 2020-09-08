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
        //[HttpPost]
        //public ActionResult Create(EmployeeModel empobj)
        //{
        //    //int i = db.save(EmpName, EmpSalary);
        //    int i = db.saveEmployee(empobj);
        //    if (i > 0) {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}


        [HttpPost]
        public ActionResult Create(FormCollection frmObj)
        {

            EmployeeModel empobj = new EmployeeModel();
            empobj.EmpName = frmObj["EmpName"];
            empobj.EmpSalary = Convert.ToInt32(frmObj["EmpSalary"]);


            int i = db.saveEmployee(empobj);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
          EmployeeModel emp= db.getEmployeeById(id);

            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel emp)
        {

            int i = db.updateEmployee(emp);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(emp);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            EmployeeModel emp = db.getEmployeeById(id);

            return View(emp);
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {

            int i = db.deleteEmployee(id);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

    }
}