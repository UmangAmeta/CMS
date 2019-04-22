using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace callmonitaringsystem2.Models
{
    [Table("Cms_Employee")]
    public class Cms_Employee
    {
   
        [Key]
        public int Employee_Id { get; set; }
        [Required(ErrorMessage="Aadharno is required")]
        public string Employee_Addharno { get; set; }

        [Required(ErrorMessage="Employee Name is required")]
        public string Employee_Name { get; set; }
        [Required(ErrorMessage="Gender is required")]
        public string Employee_Gender { get; set; }
        [Required(ErrorMessage="Email is required")]
        public string Employee_Email { get; set; }

        [Required(ErrorMessage="Dob required")]
        public DateTime Employee_Dob { get; set; }
        [Required(ErrorMessage="Employee phone required")]
        public string Employee_Phone { get; set; }

        public List<SelectListItem> Departmentname { get; set; }

      
        [Required(ErrorMessage="required and select")]
        public int Employee_Departmentid { get; set; }

        [Required(ErrorMessage="type required")]
        public string Employee_type { get; set; }
        [Required(ErrorMessage="Password required")]
        public string Employee_Password { get; set; }
        public DateTime Employee_Registerdatetime { get; set; }
    }
}