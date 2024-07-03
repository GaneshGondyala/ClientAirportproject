using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientAirportproject.Models
{
    public class Planeclass
    {
        [Required(ErrorMessage = "enter this field")]
        [RegularExpression("^[A-Z]{2}[0-9]{4}[A-Z]{1}[0-9]{3}$", ErrorMessage = "invalid Registration number Example: AB1234X567")]
        public string RegistrationNo { get; set; }
        [Required(ErrorMessage = "enter this field")]

       
        public string ModelNo { get; set; }
        [Required(ErrorMessage = "enter this field")]
        public string Plane_Name { get; set; }
        [Required(ErrorMessage = "enter this field")]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "enter this field")]
        [EmailAddress (ErrorMessage = "invalid email number \n 1. First any no. of letters letters\n2 then @ \n 3.after this gmail.com ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "enter this field")]
        public string planeownername { get; set; }
        [Required(ErrorMessage ="jkbc ")]
        public string planeownerdescription { get; set; }   



    }
}