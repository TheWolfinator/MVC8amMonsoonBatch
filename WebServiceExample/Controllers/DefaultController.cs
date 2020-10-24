using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServiceExample.ServiceReference1;
using WebServiceExample.ServiceReference2;
namespace WebServiceExample.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            ServiceReference1.AddCalculatorServiceSoapClient obj = new AddCalculatorServiceSoapClient();
            int result= obj.Add(12, 15);
            ServiceReference2.MyWcfServiceClient obj2 = new MyWcfServiceClient();
            int result2 = obj2.MyCalculator(12, 15);
            return Content(result.ToString()+","+result2.ToString());
        }
    }
}