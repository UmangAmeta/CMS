using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace callmonitaringsystem2.Models
{

    [Table("Cms_Problemdescription")]
    public class GetProblemdescriptionwithid
    {
        public string Cms_Problemdomain { get; set; }
        public string Cms_Departmentname { get; set; }

    }
}