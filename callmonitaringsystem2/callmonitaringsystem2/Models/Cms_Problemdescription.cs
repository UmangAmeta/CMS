using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace callmonitaringsystem2.Models
{
    [Table("Cms_Problemdescription")]
    public class Cms_Problemdescription
    {
        //[Key]
        //public int Cms_Descriptionid { get; set; }


    
        public List<SelectListItem> Departmentname { get; set; }


      
        public int? Cms_Departmentid { get; set; }

        [Required(ErrorMessage="Problem description is required")]
        public string Cms_Problemdomain { get; set; }
        public DateTime Cms_Problemregistertime { get; set; }
    }
}