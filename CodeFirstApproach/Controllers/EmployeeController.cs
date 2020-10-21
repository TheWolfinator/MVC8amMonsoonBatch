using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstApproach.Models;
using System.Data.Entity;

namespace CodeFirstApproach.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeContext db = new EmployeeContext();
        // GET: Employee 5th Oct' 2020 GitHub 
        public ActionResult Index()
        {

            return View(db.EmployeeModels.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel emp)
        {
            db.EmployeeModels.Add(emp);
            int i = db.SaveChanges();
            if (i > 0)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult Edit(int? id)
        {
            return View(db.EmployeeModels.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(EmployeeModel emp)
        {
            db.Entry(emp).State=EntityState.Modified;
            int i = db.SaveChanges();
            if (i > 0)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        public ActionResult Delete(int? id)
        {
            return View(db.EmployeeModels.Find(id));
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            EmployeeModel emp= db.EmployeeModels.Find(id);
            db.EmployeeModels.Remove(emp);

            int i = db.SaveChanges();
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