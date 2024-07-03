using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientAirportproject.Models
{
    public class managerclass
    {
        [Required(ErrorMessage = "Enter this field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter this field")]
        [RegularExpression("^[0-9]{11}[0-9]{1}$", ErrorMessage = "not valid EX: 123456789023")]
        public string SSN { get; set; }
        [Required(ErrorMessage = "Enter this field")]
        public System.DateTime DOB { get; set; }
        [Required(ErrorMessage = "Enter this field")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Enter this field")]
        [RegularExpression("^[0-9]{9}[0-9]{1}$", ErrorMessage = "mobile number should be 10 digits and only digits")]
        public string mobile { get; set; }
        [Required(ErrorMessage = "Enter this field")]
        [EmailAddress(ErrorMessage = "invalid email number \n 1. First any no. of letters letters\n2 then @ \n 3.after this gmail.com ")]
        public string email { get; set; }
    
    }
}