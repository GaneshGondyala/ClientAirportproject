using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientAirportproject.Models
{
    public class planeowndetailsAd
    {
        [Required(ErrorMessage ="enter this field")]
        public string name {  get; set; }
        [Required(ErrorMessage ="enter this field")]
        public string email { get; set; }       
        [Required(ErrorMessage = "enter this field")]
        public string Hno { get; set; }
        [Required(ErrorMessage = "enter this field")]
        public string Address_line1 { get; set; }
        [Required(ErrorMessage = "enter this field")]
        public string City { get; set; }
        [Required(ErrorMessage = "enter this field")]
        public string state { get; set; }
        [Required(ErrorMessage = "enter this field")]
        public string Country { get; set; }
        [Required(ErrorMessage = "enter this field")]
        [StringLength(6, ErrorMessage = "pinsode  must be 6 digits")]
        public string pincode { get; set; }
    }
}