using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using callmonitaringsystem2.Models;
using callmonitaringsystem2.Helper;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Data.SqlClient;
namespace callmonitaringsystem2.Controllers
{
    public class CmsController : Controller
    {
        Queryhandler qh = new Queryhandler();


        // GET: Cms
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Adddepartment()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Adddepartment(Cms_Department cms_department)
        {

            if (ModelState.IsValid)
            {
                cms_department.Cms_Departmentregister = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                string a = qh.Checkexist_department(cms_department);
                if (a == "Department already exists")
                {
                    ViewBag.message = "Department name is already exists";

                }
                else
                {
                    qh.AddnewDepartment(cms_department);
                    ModelState.Clear();
                }
            }
            else
            {
                ViewBag.Error = "Something went wrong";
            }
            ViewBag.Success = "Successfully register for Cms system!! ";
            return View();
        }

      
        [HttpGet]
        public ActionResult Adddepartdomain()
        {
            Cms_Problemdescription cms_getdepart = new Cms_Problemdescription();
            cms_getdepart.Departmentname = DepartmentList();
            return View(cms_getdepart);
        }

        [HttpPost]
        public ActionResult Adddepartdomain(Cms_Problemdescription cmsproblemdescription)
        {
           if(ModelState.IsValid)
           {
               cmsproblemdescription.Cms_Problemregistertime = Convert.ToDateTime(DateTime.Now.ToLongTimeString());

               cmsproblemdescription.Departmentname = DepartmentList();
               var selectedItem = cmsproblemdescription.Departmentname.Find(p => p.Value == cmsproblemdescription.Cms_Departmentid.ToString());
               if (selectedItem != null)
               {
                   selectedItem.Selected = true;
                   qh.AddDepartmentwithdescription(cmsproblemdescription);
                   ViewBag.Success = "Successfully Added!! ";
                  
               }

              
           }
                
           
           if(ViewBag.Success == null)
            {
                ViewBag.Error = "Something went wrong";
            }
           
            return View(cmsproblemdescription);
           
        }

        [HttpGet]
        public ActionResult Addemployee()
        {
           Cms_Employee cms_getdepart =new Cms_Employee();
            cms_getdepart.Departmentname = DepartmentList();
            return View(cms_getdepart);
        }

        [HttpPost]
        public ActionResult Addemployee(Cms_Employee cms_employee)
        {
            if(ModelState.IsValid)
            {
                cms_employee.Employee_Registerdatetime = Convert.ToDateTime(DateTime.Now.ToShortTimeString());

                string a = qh.Checkemployee_req(cms_employee);
                if (a == "Aadharno,email and phoneno already exists")
                {
                    ViewBag.message = "Aadharno,email and phoneno is already exists";

                }
                else
                {

                    try
                    {
                        cms_employee.Departmentname = DepartmentList();
                        var selectedItem = cms_employee.Departmentname.Find(p => p.Value == cms_employee.Employee_Departmentid.ToString());
                        if (selectedItem != null)
                        {
                            selectedItem.Selected = true;
                            qh.AddEmployee(cms_employee);
                            
                             }                      

                        
                        MailMessage mail = new MailMessage();
                        mail.To.Add(cms_employee.Employee_Email);
                        mail.From = new MailAddress("callmonitaringsystem2017@gmail.com");
                        mail.Subject = "Account creation";
                        string Body = "Hello  <b>" + cms_employee.Employee_Name + "<b><br/><br/>";
                        Body += "Your Employeement account is successfully Activate by the Administrator";
                        Body += "<br/>Your UserName and Password here:-<br/><br/>";
                        Body += "<br/>UserName= <b>" + cms_employee.Employee_Email + "<b><br/><br/>";
                        Body += "<br/>Password = <b>" + cms_employee.Employee_Password + "<b><br/><br/>";
                        Body += "<br/>This Autogenerated email please do not reply";
                        Body += "<br/>Call monitaring System ";
                        Body += "<br/>Thanks ";
                        mail.Body = Body;
                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential("callmonitaringsystem2017@gmail.com", "7976862730@umang"); // Enter seders User name and password  
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        ViewBag.Success = "Successfully Added!! ";
                        ModelState.Clear();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = "Error Occured:" + ex.Message.ToString();
                    }
       
                }
               
            }
            else
            {
                ViewBag.Error = "Something went wrong";
            }
            ViewBag.Success = "Successfully register for Cms system!! ";
            return View(cms_employee);
        }


        private static List<SelectListItem> DepartmentList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string constr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "Select Cms_Departmentid,Cms_Departmentname from Cms_department";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr["Cms_Departmentname"].ToString(),
                                Value = sdr["Cms_Departmentid"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }

            return items;
        }


        [HttpGet]
        public ActionResult ViewEmployee()
        {
            return View(qh.ListofEmployee().ToList());
        }


        [HttpGet]
        public ActionResult ViewDepartment()
        {
            return View(qh.ListofDepartment().ToList());
        }

        [HttpGet]
        public ActionResult ViewDepartmentwithdomain()
        {
            return View(qh.Listofproblemdescription().ToList());
        }
    }
}