using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace callmonitaringsystem2.Models
{
    [Table("Cms_Complainttable")]
    public class Cms_Complainttable
    {
        [Key]
        public int Complain_id { get; set; }

        public int Complain_Userid { get; set; }
        public int Complain_DepartmentId { get; set; }
        public int Complain_DescriptionId { get; set; }

        public string Complain_Status { get; set; }
        public string Complain_Relevant { get; set; }
        public DateTime Complain_Registerdatetime { get; set; }
    }
}