using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC8amMonsoonBatch.Models
{
    public class EmpDeptDetail
    {
        public EmployeeModel emp { get; set; }
        public DepartmentModel dep { get; set; }
        public List<EmployeeModel> listemp { get; set; }

    }
}