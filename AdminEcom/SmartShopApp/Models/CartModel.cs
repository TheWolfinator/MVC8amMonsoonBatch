using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DDMVC.Models;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DDMVC.Models
{
    public class CartModel
    {

        SqlConnection sqlCon = new SqlConnection("Data Source=Lenovo-PC\\SQLExpress;Initial Catalog=Ecomerce; Integrated Security=true;");
        //INSERT Into  [dbo].[Product] (id,Name,[Image],Cost)
        //values(3,'Penguins', N'C:\Users\Public\Pictures\Sample Pictures\Penguins.jpg',75.50)
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductImage { get; set; }
        public int ProductQuantity { get; set; }
        public float Cost { get; set; }

        public List<CartModel> GetProductDetails()
        {
            List<CartModel> listCart = new List<CartModel>();
            SqlCommand cmd = new SqlCommand("[dbo].[GetProductDetails]", sqlCon);
            sqlCon.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlCon.Close();
            foreach (DataRow dr in dt.Rows)
            {
                CartModel ObjDB = new CartModel();
                ObjDB.ProductID = Convert.ToInt32(dr["ProductId"].ToString());
                ObjDB.ProductName = dr["ProductName"].ToString();
                ObjDB.ProductImage = Convert.ToInt32(dr["ImageId"].ToString());
                if(dr["Price"]!=DBNull.Value)
                ObjDB.Cost = float.Parse(dr["Price"].ToString());
                listCart.Add(ObjDB);
            }
            return listCart;

        }


    }
    public class Itemsoncart
    {
        public int TotalCost { get; set; } = 0;
        public int TotalItems { get; set; } = 0;
        public List<CartModel> modList { get; set; }

    }
}