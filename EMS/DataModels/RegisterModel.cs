using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Enter First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter Second name")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Enter Surname")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Role")]
        public string Role { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwprd is wrong")]
        public string ConfirmPassword { get; set; }
    }
}
