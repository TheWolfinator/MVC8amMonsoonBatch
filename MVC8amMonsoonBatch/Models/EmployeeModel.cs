using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC8amMonsoonBatch.Models
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }
        [Display(Name ="Employee")]
        public string EmpName { get; set; }
        public int EmpSalary { get; set; }
    }
}