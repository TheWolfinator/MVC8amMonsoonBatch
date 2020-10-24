using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilterExample.Filter
{
     
    public class MyFilter :ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        { 
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            (filterContext.Result as ViewResult).ViewBag.Player = "Virat Kohli";
        }
    }
}