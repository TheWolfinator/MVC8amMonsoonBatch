using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminEcom.Models;
using System.Data.Entity;

namespace AdminEcom.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private EcomerceEntities1 db = new EcomerceEntities1();
        public ActionResult ViewProduct()
        {
            return View(db.USP_Admin_GetProductDetails().ToList());
        }
        public ActionResult Create()
        {

            var CategoryListItemNew = new List<SelectListItem>();
            var ImageListItemNew = new List<SelectListItem>();
            Product ppp = new Product();
            var items = db.Categories.ToList();
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    CategoryListItemNew.Add(new SelectListItem { Text = item.CategoryName, Value = Convert.ToString(item.CategoryId) });
                }
            }
            var items1 = db.Images.ToList();
            if (items1 != null && items1.Count > 0)
            {
                foreach (var item in items1)
                {
                    ImageListItemNew.Add(new SelectListItem { Text = item.ImageName, Value = Convert.ToString(item.ImageId) });
                }
            }
            ppp._CategoryListNew = CategoryListItemNew;
            ppp._ImageListNew = ImageListItemNew;
            return View(ppp);
        }

        //
        // POST: /ProductNew/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                product.CreationDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        //
        // GET: /ProductNew/Edit/5

        public ActionResult Edit(int id = 0)

        {
            var CategoryListItemNew = new List<SelectListItem>();
            var ImageListItemNew = new List<SelectListItem>();
            Product ppp = new Product();
            var items = db.Categories.ToList();
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    CategoryListItemNew.Add(new SelectListItem { Text = item.CategoryName, Value = Convert.ToString(item.CategoryId) });
                }
            }
            var items1 = db.Images.ToList();
            if (items1 != null && items1.Count > 0)
            {
                foreach (var item in items1)
                {
                    ImageListItemNew.Add(new SelectListItem { Text = item.ImageName, Value = Convert.ToString(item.ImageId) });
                }
            }
            Product product = db.Products.Find(id);
            product._CategoryListNew = CategoryListItemNew;
            product._ImageListNew = ImageListItemNew;


            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /ProductNew/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                product.UpdationDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

    }
}