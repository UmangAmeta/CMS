using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace callmonitaringsystem2.Models
{
    public class Cms_userlogin
    {
        [Required(ErrorMessage = "Email is required")]
        public string User_Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string User_Password { get; set; }
      
    }
}