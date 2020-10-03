using DDMVC.Models;
using SmartShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartShopApp.Controllers
{
    public class SmartShopController : Controller
    {
        // GET: SmartSh
        private EcomerceEntities db = new EcomerceEntities();

        [HttpGet]
        public ActionResult Index()

        {
            return View(db.USP_Admin_GetProductDetails().ToList());
        }
        [HttpPost]
        public ActionResult Index(USP_Admin_GetProductDetails_Result cartobj)
        {
            if (Session["Cart"] != null)
            {
                USP_Admin_GetProductDetails_Result Sessionobj = (USP_Admin_GetProductDetails_Result)Session["Cart"];
                if (Sessionobj.ProductId == cartobj.ProductId)
                {

                    Sessionobj.Quantity = Sessionobj.Quantity + 1;
                    Sessionobj.Price= Sessionobj.Price + Convert.ToSingle(cartobj.Price);
                    List<USP_Admin_GetProductDetails_Result> cartinfo =new  List<USP_Admin_GetProductDetails_Result>();
                    cartinfo.Add(Sessionobj);
                    Session["Cart"] =cartinfo;
                   
                }
            }
            else
            {
                CartModel SessionFirstTimeObj = new CartModel();
                SessionFirstTimeObj.ProductID = cartobj.ProductId;
                SessionFirstTimeObj.ProductQuantity = 1;
                SessionFirstTimeObj.Cost = Convert.ToSingle(cartobj.Price);             
                Session["Cart"] = SessionFirstTimeObj;

            }
            return View(Session["Cart"]);
        }
        public ActionResult ProductDetail()
        {
            return View();
        }
    }
}