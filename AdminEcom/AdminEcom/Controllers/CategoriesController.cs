using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminEcom.Models;
using System.Data.Entity;

namespace AdminEcom.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories

        private EcomerceEntities1 db = new EcomerceEntities1();
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        public void DropDownActiveDeactive()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Active", Value = "1" });
            items.Add(new SelectListItem { Text = "Dactive", Value = "0" });
            ViewData["ListItems"] = items;
        }

        //
        // GET: /Category/
        private void DropDownReBind()
        {
            List<SelectListItem> SelYN = new List<SelectListItem>();

            SelYN.Add(new SelectListItem
            {
                Text = "Active",
                Value = "1"
            });
            SelYN.Add(new SelectListItem
            {
                Text = "Deactive",
                Value = "0"
            });

            ViewData["selYN"] = SelYN;
        }
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    return View(db.Categories.OrderBy(x => x.CategoryName).ToList());

        //}
        [HttpGet]
        public ActionResult Index(string search)
        {
            //  return View(db.Categories.OrderBy(x => x.CategoryName).ToList());

            //List<string> IsActive1 = new List<string>();
            //IsActive1.Add("Active");
            //IsActive1.Add("Dctive");

            //var Category1=new Category();
            //ViewData["ListItems"] = Category1.Listitems;


            if (search == null)
            {
                //Index action} method will return a view with a student records based on what a user specify the value in textbox  
                return View(db.Categories.OrderBy(x => x.CategoryName).ToList());

            }
            else
            {
                return View(db.Categories.Where(x => x.CategoryName.StartsWith(search)).OrderBy(x => x.CategoryName).ToList());

            }
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id = 0)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {

                db.Categories.Add(category);
                category.CreationDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {

                category.UpdationDate = DateTime.Now;
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //
        // GET: /Category/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}