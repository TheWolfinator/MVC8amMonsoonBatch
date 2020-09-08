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
        public int saveEmployee(EmployeeModel eobj)
        {
            SqlCommand cmd = new SqlCommand("sp_insert", con);//select ,insert,update delete
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpName", eobj.EmpName);
            cmd.Parameters.AddWithValue("@EmpSalary", eobj.EmpSalary);
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }



        public EmployeeModel getEmployeeById(int? id)
        {

            EmployeeModel empObj = new EmployeeModel();


            SqlCommand cmd = new SqlCommand("sp_getEmployeeById", con);//select ,insert,update delete
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);//select stmt
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                empObj.EmpId = Convert.ToInt32(dr[0]);
                empObj.EmpName = Convert.ToString(dr[1]);
                empObj.EmpSalary = Convert.ToInt32(dr[2]);

            }
            return empObj;
        }



        public int updateEmployee(EmployeeModel eobj)
        {
            SqlCommand cmd = new SqlCommand("sp_updateEmployee", con);//select ,insert,update delete
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", eobj.EmpId);
            cmd.Parameters.AddWithValue("@EmpName", eobj.EmpName);
            cmd.Parameters.AddWithValue("@EmpSalary", eobj.EmpSalary);
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }



        public int deleteEmployee(int? id)
        {
            SqlCommand cmd = new SqlCommand("sp_deleteEmployee", con);//select ,insert,update delete
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", id);

            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }

    }
}