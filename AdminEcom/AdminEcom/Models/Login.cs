using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminEcom.Models
{
    public class Login
    {
         [Required(ErrorMessage = "Email Id Required")]
         [DisplayName("Email ID")]
         [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", 
                                    ErrorMessage = "Email Format is wrong")]
         [StringLength(50, ErrorMessage = "Less than 50 characters")]
         public string Email
         {
            get; set;
         }
  
         [DataType(DataType.Password)]
         [Required(ErrorMessage="Password Required")]
         [DisplayName("Password")]
         [StringLength(30, ErrorMessage = ":Less than 30 characters")]
         public string Password
         {
            get;  set;
         }
  
         public bool IsUserExist(string emailid, string password)
         {
            bool flag =  false;
            SqlConnection connection = new SqlConnection( 
    System.Configuration.ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("select count(*) from Customer where Email='" + emailid + "' and Password='" + password + "'", connection);
            flag = Convert.ToBoolean(command.ExecuteScalar());
            connection.Close();
            return flag;
         }
    }
     public class Register
    {
         [Required(ErrorMessage = "CustomerName Required:")]
         [DisplayName("First Name:")]
         [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$",ErrorMessage="Special Characters not allowed")]
         [StringLength(50, ErrorMessage = "Less than 50 characters")]
         public string CustomerName { get; set; }
  
         
  
         [Required(ErrorMessage="EmailId Required:")]
         [DisplayName("Email Id:")]
         [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", 
                                                ErrorMessage = "Email Format is wrong")]
         [StringLength(50, ErrorMessage = "Less than 50 characters")]
         public string Email { get; set; }
  
         [Required(ErrorMessage="Password Required:")]
         [DataType(DataType.Password)]
         [DisplayName("Password:")]
         [StringLength(30, ErrorMessage = "Less than 30 characters")]
         public string Password { get; set; }
  
         [Required(ErrorMessage="Confirm Password Required:")]
         [DataType(DataType.Password)]
         [System.Web.Mvc.Compare("Password", ErrorMessage = "Confirm not matched.")]
         [Display(Name =  "Confirm password:")]
         [StringLength(30, ErrorMessage = "Less than 30 characters")]
         public string ConfirmPassword { get;  set; }

         [Required(ErrorMessage = "Mobile number Required")]
         [DisplayName("Mobile Number:")]
         [StringLength(20, ErrorMessage = "10 digst")]
         public string Mobile { get; set; }
  
         [Required(ErrorMessage="Street Address Required")]
         [DisplayName("Street Address1:")]
         [StringLength(100, ErrorMessage = "Less than 100 characters")]
         public string Address1 { get; set; }
  
         [DisplayName("Street Address2:")]
         [StringLength(100, ErrorMessage = "Less than 100 characters")]
         public string Address2 { get; set; }

         [Required(ErrorMessage = "Enter Verification Code")]
         [DisplayName("Verification Code:")]
         public string Captcha { get; set; }
           
         public bool IsUserExist(string emailid)
         {
            bool flag =  false;
            SqlConnection connection = new   SqlConnection
     (System.Configuration.ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("select count(*) from Customer where Email='" + emailid + "'", connection);
            flag = Convert.ToBoolean(command.ExecuteScalar());
            connection.Close();
            return flag;
         }
  
         public bool Insert()
         {
            bool flag =  false;
            if (!IsUserExist(Email))
            {
                SqlConnection connection = new SqlConnection
     (System.Configuration.ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("insert into Customer values('" + CustomerName + "','" + Password + "','" + Email + "', '" + Mobile + "','" + Address1 + "','" + Address2 + "', '" + null + "','" + null + "')", connection);
                flag = Convert.ToBoolean(command.ExecuteNonQuery());
                connection.Close();
                return flag;
            }
            return flag;
         }
         
    }
     public class CaptchImageAction : ActionResult
     {
         public Color BackgroundColor { get; set; }
         public Color RandomTextColor { get; set; }
         public string RandomText { get; set; }
         public override void ExecuteResult(ControllerContext context)
         {
             RenderCaptchaImage(context);
         }
         private void RenderCaptchaImage(ControllerContext context)
         {
             Bitmap objBmp = new Bitmap(150, 60);
             Graphics objGraphic = Graphics.FromImage(objBmp);
             objGraphic.Clear(BackgroundColor);
             SolidBrush objBrush = new SolidBrush(RandomTextColor);
             Font objFont = null;
             int a;
             string myFont, str;
             string[] crypticsFont = new string[11];
             crypticsFont[0] = "Times New roman";
             crypticsFont[1] = "Verdana";
             crypticsFont[2] = "Sylfaen";
             crypticsFont[3] = "Microsoft Sans Serif";
             crypticsFont[4] = "Algerian";
             crypticsFont[5] = "Agency FB";
             crypticsFont[6] = "Andalus";
             crypticsFont[7] = "Cambria";
             crypticsFont[8] = "Calibri";
             crypticsFont[9] = "Courier";
             crypticsFont[10] = "Tahoma";
             for (a = 0; a < RandomText.Length; a++)
             {
                 myFont = crypticsFont[a];
                 objFont = new Font(myFont, 18, FontStyle.Bold | FontStyle.Italic |
                                                                   FontStyle.Strikeout);
                 str = RandomText.Substring(a, 1);
                 objGraphic.DrawString(str, objFont, objBrush, a * 20, 20);
                 objGraphic.Flush();
             }
             context.HttpContext.Response.ContentType = "image/GF";
             objBmp.Save(context.HttpContext.Response.OutputStream, ImageFormat.Gif);
             objFont.Dispose();
             objGraphic.Dispose();
             objBmp.Dispose();
         }
     }
}