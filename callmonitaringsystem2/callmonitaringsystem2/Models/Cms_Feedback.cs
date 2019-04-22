using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace callmonitaringsystem2.Models
{
    [Table("Cms_Feedback")]
    public class Cms_Feedback
    {
        [Key]
        public int Feedback_id { get; set; }
        public int Feedback_Complainid { get; set; }
        public string Feedback_Status { get; set; }
    }
}