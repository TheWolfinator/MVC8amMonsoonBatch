using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
//using System.Data.E
namespace CodeFirstApproach.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext():base("EmployeeEntities")
        {

        }

        public DbSet<EmployeeModel> EmployeeModels { get; set; }

    }
}