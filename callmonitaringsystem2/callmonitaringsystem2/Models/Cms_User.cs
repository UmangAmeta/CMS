using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace callmonitaringsystem2.Models
{
    [Table("Cms_User")]
    public class Cms_User
    {
        //[Key]
        //public int User_Id { get; set; }
        [Required(ErrorMessage = "Name required")]
        public string User_Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string User_Email { get; set; }
        [Required(ErrorMessage = "Phone no is required")]
        public string User_Phoneno { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime User_Dob { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string User_Gender { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string User_Password { get; set; }
        public string User_Type { get; set; }
        public DateTime User_Registerdatetime { get; set; }
    }
}