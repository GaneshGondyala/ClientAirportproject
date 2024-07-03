using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientAirportproject.Models
{
    public class hangerclass
    {
        [Required(ErrorMessage ="enter this field")]
        public string Location { get; set; }
        [Required(ErrorMessage = "select this field")]
        public string Manager_Id { get; set; }
        [Required(ErrorMessage = "enter this field")]
        public int Capacity { get; set; }
       

    }
}