using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientAirportproject.Models
{
    public class Plane_hanger
    {

        [Required(ErrorMessage ="enter this field")]
        public string Hanger_Id { get; set; }
        [Required(ErrorMessage = "enter this field")]
        public string Plane_Id { get; set; }
        [Required(ErrorMessage = "enter this field")]
        public System.DateTime fromdate { get; set; }
        [Required(ErrorMessage = "enter this field")]
        public System.DateTime todate { get; set; }

    }
}