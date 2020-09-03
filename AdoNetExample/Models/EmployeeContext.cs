using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AdoNetExample.Models
{
    public class EmployeeContext
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        public List<EmployeeModel> GetEmployee()
        {

            List<EmployeeModel> listobj = new List<EmployeeModel>();

            SqlCommand cmd = new SqlCommand("sp_getEmployee", con);//select ,insert,update delete
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);//select stmt
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeModel empObj = new EmployeeModel();
                empObj.EmpId = Convert.ToInt32(dr[0]);
                empObj.EmpName = Convert.ToString(dr[1]);
                empObj.EmpSalary = Convert.ToInt32(dr[2]);
                listobj.Add(empObj);
            }
            return listobj;
        }
    }
}