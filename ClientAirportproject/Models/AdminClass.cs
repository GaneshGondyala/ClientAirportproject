using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientAirportproject.Models
{
    public class AdminClass
    {
        [Required(ErrorMessage = "Required")]
        public string username { get; set; }
        [Required(ErrorMessage = "Required")]
        public string password { get; set; }
    }
}