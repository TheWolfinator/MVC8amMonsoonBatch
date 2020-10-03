using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC8amMonsoonBatch.Models
{
    public class EmployeeModel
    {
        [ScaffoldColumn(false)]
        public int EmpId { get; set; }
        [Display(Name ="Employee")]
        public string EmpName { get; set; }
        public int EmpSalary { get; set; }
        public bool Status { get; set; }
        public Languages lang { get; set; }
        public int LangId { get; set; }
    }
}