using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using callmonitaringsystem2.Models;
using callmonitaringsystem2.Helper;
using System.Net.Mail;
using System.Net;
namespace callmonitaringsystem2.Controllers
{

    public class HomeController : Controller
    {
        Queryhandler qh = new Queryhandler();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Cms_userlogin cms_userlogin)
        {
            if (ModelState.IsValid)
            {
                string email, password, a;
                email = cms_userlogin.User_Email;
                password = cms_userlogin.User_Password;
                a = qh.Checkuser_req(email, password);
                if (a == "email and paasword is not correct")
                {
                    ViewBag.message = "email and paasword is not correct";
                }
                else
                {
                    ViewBag.message = email;
                    return RedirectToAction("Admin", "Cms");
                }
            }
            else
            {
                ViewBag.Error = "Something went wrong";
            }
            return View();
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Cms_User cms_user)
        {
            if (ModelState.IsValid)
            {
                cms_user.User_Type = "User";
                cms_user.User_Registerdatetime = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                string a = qh.Checkdata_req(cms_user);
                if (a == "email and phoneno already exists")
                {
                    ViewBag.message = "User Email and phoneno is already exists";

                }
                else
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(cms_user.User_Email);
                    mail.From = new MailAddress("callmonitaringsystem2017@gmail.com");
                    mail.Subject = "<b>HAccount creation<b>";
                    string Body = "<b>Hello  <b>" + cms_user.User_Name + "<b><br/><br/>";
                    Body += "Your account is successfully created for the CMS system";
                    Body += "<br/>Your UserName and Password here:-<br/><br/>";
                    Body += "<br/>UserName= <b>" + cms_user.User_Email + "<br/><br/>";
                    Body += "<br/>Password = <b>" + cms_user.User_Password + "<br/><br/>";
                    Body += "<br/>Thanks";
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("callmonitaringsystem2017@gmail.com", "7976862730@umang"); // Enter seders User name and password  
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    qh.Addnewuser(cms_user);
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
        public ActionResult sendemail()
        {
            return View();
        }
        

        [HttpPost]
        public ViewResult sendemail(MailModel _objModelMail)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("callmonitaringsystem2017@gmail.com", "7976862730@umang"); // Enter seders User name and password  
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("sendemail", _objModelMail);
            }
            else
            {
                return View();
            }  
        }
    }
}