using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopSmartApp.Models;
using System.Collections;
namespace ShopSmartApp.Controllers
{
    public class CartController : Controller
    {
        static CartModel modCart = new CartModel();
        Itemsoncart ICart = new Itemsoncart();

        static ArrayList alProductsAdded = new ArrayList();
        // GET: Cart
        public ActionResult DisplayProducts()
        {
            List<CartModel> ProductsList = modCart.GetProductDetails();
            return View(ProductsList);
        }

        [HttpPost]     
      
        public ActionResult AddToCart(int id)
        {
           int ProductID= id;
            string ProductName=""; int Cost=25;
            if (Session["ItemsonCart"] == null)
            {
                ICart.modList = new List<CartModel>();
            }

            if (Session["ItemsonCart"] != null)
            {
                ICart = (Itemsoncart)Session["ItemsonCart"];
            }
            if (!alProductsAdded.Contains(ProductID))
            {
                alProductsAdded.Add(ProductID);
                modCart.ProductID = ProductID;
                modCart.ProductName = ProductName;
                modCart.Cost = Convert.ToInt16(Cost);
                modCart.ProductQuantity = 1;

                ICart.modList.Add(modCart);
                ICart.TotalCost = ICart.TotalCost + Convert.ToInt16(Cost);
                ICart.TotalItems = ICart.TotalItems + 1;

            }
            else
            {
                foreach (CartModel CM in ICart.modList)
                {
                    if (CM.ProductID == ProductID)
                    {
                        CM.ProductQuantity = CM.ProductQuantity + 1;
                    }
                }

                ICart.TotalCost = ICart.TotalCost + Convert.ToInt16(Cost);
                //ICart.TotalItems = ICart.TotalItems + 1;
            }

            Session["ItemsonCart"] = ICart;
            return View();
        }
    }
}