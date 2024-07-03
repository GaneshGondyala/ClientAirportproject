using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientAirportproject.Models.BAO
{
    
        public sealed class Metadata
        {
            [Required(ErrorMessage = "cannot be blank")]
            //[StringLength(20, ErrorMessage = "user must max 25")]
            public string Username { get; set; }
            [Required(ErrorMessage = "cannot be blank")]
            public string Password { get; set; }
            public string Usertype { get; set; }
        }
    
}