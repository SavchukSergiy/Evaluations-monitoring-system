using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwprd is wrong")]
        public string ConfirmPassword { get; set; }
    }
}
