using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace callmonitaringsystem2.Models
{

    [Table("Cms_Department")]
    public class Cms_getdepartment
    {

        public List<SelectListItem> Departmentname { get; set; }
        public int Cms_Departmentid { get; set; }

        public string Cms_Departmentname { get; set; }
    }
}