using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace callmonitaringsystem2.Models
{
    [Table("Cms_Department")]
    public class Cms_Department
    {
        [Key]
        public int Cms_Departmentid { get; set; }
        [Required(ErrorMessage="Department name required")]
        public string Cms_Departmentname { get; set; }
        public DateTime Cms_Departmentregister { get; set; }
    }
}