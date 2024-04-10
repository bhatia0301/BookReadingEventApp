using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookReadingApp.Core.Modals
{
    public class Login
    {
        [Required(ErrorMessage = "Please enter your UserName")]
        [Display(Name = "User Name")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Please enter your Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password, ErrorMessage = "Please Provide a Valid Password")]
        public string password { get; set; }
    }
}
