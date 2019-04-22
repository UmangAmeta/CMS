using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace callmonitaringsystem2.Models
{
    [Table("Cms_Employee")]
    public class GetEmployee
    {

        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }
        public string Employee_Email { get; set; }
        public string Employee_Phoneno { get; set; }
        public string Departmentname { get; set; }

    }
}