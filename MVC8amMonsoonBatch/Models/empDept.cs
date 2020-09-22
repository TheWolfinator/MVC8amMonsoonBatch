using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC8amMonsoonBatch.Models
{
    public class empDept
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int? EmpSalary { get; set; }

        public string DepartName { get; set; }
    }
}