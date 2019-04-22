using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace callmonitaringsystem2.Models
{
    public class Cmscontrol:DbContext
    {
        public DbSet<Cms_User> cms_user { get; set; }
        public DbSet<Cms_Employee> cms_emp { get; set; }
        public DbSet<Cms_Department> cms_depart { get; set; }
        public DbSet<Cms_Complainttable> cms_complain { get; set; }
        public DbSet<Cms_Problemdescription> cms_desc { get; set; }
        public DbSet<Cms_Feedback> cms_feed { get; set; }

    }
}