using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientAirportproject.Models
{
    public class PlaneOnly
    {
        [Required(ErrorMessage = "enter this field")]
        [RegularExpression("^[A-Z]{2}[0-9]{4}[A-Z]{1}[0-9]{3}$", ErrorMessage = "invalid Registration number \n 1. First 2 capital letters\n2.then four numeric digits \n 3.a capital Letter \n4. three digits")]
        public string RegistrationNo { get; set; }
        [Required(ErrorMessage = "enter this field")]
     
        public string ModelNo { get; set; }
        [Required(ErrorMessage = "enter this field")]
        public string Plane_Name { get; set; }
        [Required(ErrorMessage = "enter this field")]
        public int Capacity { get; set; }
      
       
    
        
    }
}