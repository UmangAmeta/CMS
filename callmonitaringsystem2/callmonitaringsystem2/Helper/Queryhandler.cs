using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using callmonitaringsystem2.Models;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace callmonitaringsystem2.Helper
{
    public class Queryhandler
    {
        Cmscontrol cms = new Cmscontrol();
        private string conn = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        private SqlConnection con;

        public Queryhandler()
        {
            con = new SqlConnection(conn);
        }




        public string Checkdata_req(Cms_User cmsuser)
        {
            string useremail, phoneno;
            useremail = cmsuser.User_Email;
            phoneno = cmsuser.User_Phoneno;

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * from Cms_User Where User_Email=@useremail and User_Phoneno=@phoneno";
            cmd.Parameters.AddWithValue("@useremail", useremail);
            cmd.Parameters.AddWithValue("@phoneno", phoneno);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            con.Close();

            if (ds.Tables[0].Rows.Count != 0)
            {
                return "email and phoneno already exists";
            }

            return "User succcess";

        }

        public string Checkexist_department(Cms_Department cmsuser)
        {
            string department;
            department = cmsuser.Cms_Departmentname;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * from Cms_Department Where Cms_Departmentname=@department";
            cmd.Parameters.AddWithValue("@department", department);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            con.Close();

            if (ds.Tables[0].Rows.Count != 0)
            {
                return "Department already exists";
            }

            return "Added succeess fully";

        }
        public bool AddnewDepartment(Cms_Department cmsdepartment)
        {
            string departmentname, regdate;
            try
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction();

                try
                {
                    departmentname = cmsdepartment.Cms_Departmentname;
                    regdate = cmsdepartment.Cms_Departmentregister.ToString();
                    SqlCommand dbcmd = con.CreateCommand();
                    dbcmd.Transaction = trans;
                    dbcmd.CommandText = "insert into Cms_Department(Cms_Departmentname,Cms_Departmentregister) Values(@departmentname,@regdate)";
                    dbcmd.Parameters.AddWithValue("@departmentname", departmentname);
                    dbcmd.Parameters.AddWithValue("@regdate", regdate);
                    dbcmd.ExecuteNonQuery();
                    trans.Commit();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    con.Close();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }



        public bool AddDepartmentwithdescription(Cms_Problemdescription cms_problemdescription)
        {
            string departmentid, departmentdescription, regdate;
            try
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction();

                try
                {
                    departmentid = Convert.ToString(cms_problemdescription.Cms_Departmentid);
                    departmentdescription = cms_problemdescription.Cms_Problemdomain;
                    regdate = cms_problemdescription.Cms_Problemregistertime.ToString();
                    SqlCommand dbcmd = con.CreateCommand();
                    dbcmd.Transaction = trans;
                    dbcmd.CommandText = "insert into Cms_Problemdescription(Cms_Departmentid,Cms_Problemdomain,Cms_Problemregistertime) Values(@departmentid,@departmentdescription,@regdate)";
                    dbcmd.Parameters.AddWithValue("@departmentid", departmentid);
                    dbcmd.Parameters.AddWithValue("@departmentdescription", departmentdescription);
                    dbcmd.Parameters.AddWithValue("@regdate", regdate);
                    dbcmd.ExecuteNonQuery();
                    trans.Commit();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    con.Close();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }



        public bool Addnewuser(Cms_User cms_user)
        {
            string username, useremail, phoneno, dob, gender, password, status, regdate;
            try
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction();

                try
                {
                    username = cms_user.User_Name;
                    useremail = cms_user.User_Email;
                    phoneno = cms_user.User_Phoneno;
                    dob = cms_user.User_Dob.ToString();
                    gender = cms_user.User_Gender;
                    password = cms_user.User_Password;
                    status = cms_user.User_Type;
                    regdate = cms_user.User_Registerdatetime.ToString();
                    SqlCommand dbcmd = con.CreateCommand();
                    dbcmd.Transaction = trans;

                    dbcmd.CommandText = "insert into Cms_User(User_Name,User_Email,User_Phoneno,User_Dob,User_Gender,User_Password,User_Type,User_Registerdatetime) Values(@username,@useremail,@phoneno,@dob,@gender,@password,@status,@registerdatetime)";
                    dbcmd.Parameters.AddWithValue("@username", username);
                    dbcmd.Parameters.AddWithValue("@useremail", useremail);
                    dbcmd.Parameters.AddWithValue("@phoneno", phoneno);
                    dbcmd.Parameters.AddWithValue("@dob", dob);
                    dbcmd.Parameters.AddWithValue("@gender", gender);
                    dbcmd.Parameters.AddWithValue("@password", password);
                    dbcmd.Parameters.AddWithValue("@status", status);
                    dbcmd.Parameters.AddWithValue("@registerdatetime", regdate);
                    dbcmd.ExecuteNonQuery();

                    trans.Commit();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    con.Close();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        public string Checkemployee_req(Cms_Employee cms_emp)
        {
            string empemail, empphoneno, empaadharno;
            empaadharno = cms_emp.Employee_Addharno;
            empemail = cms_emp.Employee_Email;
            empphoneno = cms_emp.Employee_Phone;

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * from Cms_Employee Where Employee_Addharno=@empaadharno and Employee_Email=@empemail and Employee_Phone=@empphoneno";
            cmd.Parameters.AddWithValue("@empaadharno", empaadharno);
            cmd.Parameters.AddWithValue("@empemail", empemail);
            cmd.Parameters.AddWithValue("@empphoneno", empphoneno);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            con.Close();

            if (ds.Tables[0].Rows.Count != 0)
            {
                return "Aadharno,email and phoneno already exists";
            }

            return "User succcess";

        }




        public bool AddEmployee(Cms_Employee cms_employee)
        {
            string emp_aadharno, emp_username, emp_gender, emp_email, emp_phone, emp_type, emp_depid, emp_password, emp_dob, emp_regdate;

            try
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction();

                try
                {
                    emp_aadharno = cms_employee.Employee_Addharno;
                    emp_username = cms_employee.Employee_Name;
                    emp_gender = cms_employee.Employee_Gender;
                    emp_email = cms_employee.Employee_Email;
                    emp_dob = cms_employee.Employee_Dob.ToString();
                    emp_phone = cms_employee.Employee_Phone;
                    emp_depid = Convert.ToString(cms_employee.Employee_Departmentid);
                    emp_type = cms_employee.Employee_type;
                    emp_password = cms_employee.Employee_Password;
                    emp_regdate = cms_employee.Employee_Registerdatetime.ToString();
                    SqlCommand dbcmd = con.CreateCommand();
                    dbcmd.Transaction = trans;
                    dbcmd.CommandText = "insert into Cms_Employee(Employee_Addharno,Employee_Name,Employee_Gender,Employee_Email,Employee_Dob,Employee_Phone,Employee_Departmentid,Employee_type,Employee_Password,Employee_Registerdatetime) Values(@empaadharno,@empname,@empgender,@empemail,@empdob,@empphone,@empdepid,@emptype,@emppassword,@empregdate)";
                    dbcmd.Parameters.AddWithValue("@empaadharno", emp_aadharno);
                    dbcmd.Parameters.AddWithValue("@empname", emp_username);
                    dbcmd.Parameters.AddWithValue("@empgender", emp_gender);
                    dbcmd.Parameters.AddWithValue("@empemail", emp_email);
                    dbcmd.Parameters.AddWithValue("@empdob", emp_dob);
                    dbcmd.Parameters.AddWithValue("@empphone", emp_phone);
                    dbcmd.Parameters.AddWithValue("@empdepid", emp_depid);
                    dbcmd.Parameters.AddWithValue("@emptype", emp_type);
                    dbcmd.Parameters.AddWithValue("@emppassword", emp_password);
                    dbcmd.Parameters.AddWithValue("@empregdate", emp_regdate);
                    dbcmd.ExecuteNonQuery();

                    trans.Commit();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    con.Close();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }



        public string Checkuser_req(string email, string password)
        {

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * from Cms_User Where User_Email=@email and User_Password=@password";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            con.Close();

            if (ds.Tables[0].Rows.Count == 0)
            {
                return "email and paasword is not correct";
            }

            return "User succcess";

        }

        public List<GetEmployee> ListofEmployee()
        {
            List<GetEmployee> cms_employee = new List<GetEmployee>();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select Employee_Id,Employee_Name,Employee_Email,Employee_Phone,Cms_Departmentname from Cms_Employee join Cms_Department on Cms_Employee.Employee_Departmentid=Cms_Department.Cms_Departmentid";
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            ds.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                cms_employee.Add(
                   new GetEmployee
                   {
                       Employee_Id = Convert.ToInt32(dr["Employee_Id"]),
                       Employee_Name = Convert.ToString(dr["Employee_Name"]),
                       Employee_Email = Convert.ToString(dr["Employee_Email"]),
                       Employee_Phoneno = Convert.ToString(dr["Employee_Phone"]),
                       Departmentname = Convert.ToString(dr["Cms_Departmentname"])

                   }
                   );
            }

            return cms_employee;

        }


        public List<Cms_departmentwithHod> ListofDepartment()
        {
            
            List<Cms_departmentwithHod> cms_departHod = new List<Cms_departmentwithHod>();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select Cms_Departmentid, Cms_Departmentname,Cms_Employee.Employee_Name from Cms_Department join Cms_Employee on Cms_Department.Cms_Departmentid=Cms_Employee.Employee_Departmentid where Employee_type='Hod'";
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            ds.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                cms_departHod.Add(
                   new Cms_departmentwithHod
                   {
                       Cms_Departmentid = Convert.ToInt32(dr["Cms_Departmentid"]),
                       Cms_Departmentname = Convert.ToString(dr["Cms_Departmentname"]),
                       Employee_Name=Convert.ToString(dr["Employee_Name"])
                   }
                   );
            }

            return cms_departHod;

        }


        public List<GetProblemdescriptionwithid> Listofproblemdescription()
        {

            List<GetProblemdescriptionwithid> cms_problemdescription = new List<GetProblemdescriptionwithid>();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select Cms_Problemdescription.Cms_Problemdomain,Cms_Department.Cms_Departmentname from Cms_Problemdescription join Cms_Department on Cms_Problemdescription.Cms_Departmentid=Cms_Department.Cms_Departmentid";

            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            ds.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                cms_problemdescription.Add(
                   new GetProblemdescriptionwithid
                   {
                       Cms_Problemdomain=Convert.ToString(dr["Cms_Problemdomain"]),
                       Cms_Departmentname = Convert.ToString(dr["Cms_Departmentname"])
                   }
                   );
            }

            return cms_problemdescription;

        }



    }
}

