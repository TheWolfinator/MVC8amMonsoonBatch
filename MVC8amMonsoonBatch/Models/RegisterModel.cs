using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC8amMonsoonBatch.Models
{
    public class RegisterModel
    {
        [Key]
        public int CustId { get; set; }
        [Required(ErrorMessage ="Name Cannot be Empty!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password Cannot be Empty!")]
        [Display(Name="Password")]
        public string Pwd { get; set; }
        [Display(Name = "Confirm Password")]
        [Compare("Pwd", ErrorMessage = "Confirm Password and Password MisMatch!")]
        public string CPwd { get; set; }
        [Range(18,50, ErrorMessage = "Age Should between 18 to 50")]
        public int Age { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Id")]
        public string EmailId { get; set; }
        [StringLength(10, ErrorMessage = "Max Length of Character 10")]
        public string Address { get; set; }
    }
}