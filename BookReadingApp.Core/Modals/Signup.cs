using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookReadingApp.Core.Modals
{
    public class Signup
    {
        [Required(ErrorMessage = "Please Enter your UserName")]
        [Display(Name = "User Name")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Please enter your Email Address")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "PLease provide a valid Email Address")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter your Password")]
        [Display(Name = "Password")]
        [Compare("confirmPassword", ErrorMessage = "Password does not match")]
        [DataType(DataType.Password, ErrorMessage = "Please Provide a valid Password")]
        public string password { get; set; }

        [Required(ErrorMessage = "Please confirm your Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password, ErrorMessage = "Password does not match")]
        public string confirmPassword { get; set; }
    }
}
