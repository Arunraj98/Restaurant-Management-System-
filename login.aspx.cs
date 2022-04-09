using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;


using System.Net.Mail;
using System.Net;






public partial class login : System.Web.UI.Page
{
    string uname,pwd,role,status;

    MySqlDataReader dr,dr1;
    public string ConString = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
               

    
    protected void txtpswd_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        MySqlConnection con = new MySqlConnection(ConString);
        con.Open();
        MySqlCommand cmd = new MySqlCommand("select username,password,role,status from login where username='" + txtname.Text + "' and password='" + txtpswd.Text + "'", con);

        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            uname = dr[0].ToString();
            pwd = dr[1].ToString();
            role = dr[2].ToString();
            status = dr[3].ToString();


            Session["user"] = dr[0].ToString();
            Session["pass"] = dr[1].ToString();


            String type = dr[2].ToString();

            if (status == "Approved"|| status=="Unblock")
            {
                if (role == "admin")
                {
                    Response.Redirect("~/Adminhome.aspx");
                }


               
                if (role == "customer")
                {


                  

                        MySqlConnection con1 = new MySqlConnection(ConString);
                        con1.Open();
                        MySqlCommand cmd1 = new MySqlCommand("select name,address,phoneno,emailid from customerregisration where emailid='" + txtname.Text + "'", con1);

                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            Session["n"] = dr1[0].ToString();
                            Session["a"] = dr1[1].ToString();
                            Session["p"] = dr1[2].ToString();
                            Session["e"] = dr1[3].ToString();


                        }






                        Response.Redirect("~/customer__main_home.aspx");
                 
                }

                if ((role == "Delivery staff") && ((status == "Approved") || (status == "Unblock")))
                {
                    Response.Redirect("~/delivery_home.aspx");

                }


                if ((role == "Order management manager") && ((status == "Approved") || (status == "Unblock")))
                {
                    Response.Redirect("~/om_manager_home.aspx");
                }
                if ((role == "Packing manager") && ((status == "Approved") || (status == "Unblock")))
                {
                    Response.Redirect("~/packing_home.aspx");

                }
                if ((role == "Production manager") && ((status == "Approved") || (status == "Unblock")))
                {
                    Response.Redirect("~/production_home.aspx");

                }

                if ((role == "Delivery staff") && ((status == "Approved") || (status == "Unblock")))
                {
                    Response.Redirect("~/delivery_home.aspx");

                }

            

            }
            else
            {
                Response.Write("<script>alert('User name or password incorrect or Your access has been denied')</script>");
            }

        }
        else
        {
            Response.Write("<script>alert('User name or password incorrect')</script>");
        }


        

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/customer_registration.aspx");
    }





    protected void LinkButton2_Click(object sender, EventArgs e)
    {



        MySqlConnection con3 = new MySqlConnection(ConString);
        con3.Open();
        MySqlCommand cmd3 = new MySqlCommand("select password from login where username='" + txtname.Text + "'", con3);

        string pass = cmd3.ExecuteScalar().ToString();

        MailMessage MyMailMessage = new MailMessage();

        MyMailMessage.From = new MailAddress("rmsminiproject@gmail.com");


        MyMailMessage.To.Add(txtname.Text);

        MyMailMessage.Subject = " Your account details";

        MyMailMessage.Body = "your password :" + pass + " please change your password as soon as enter into your account";

        MyMailMessage.IsBodyHtml = true;

        SmtpClient SMTPServer = new SmtpClient("smtp.gmail.com");

        SMTPServer.Port = 587;

        SMTPServer.Credentials = new System.Net.NetworkCredential("rmsminiproject@gmail.com", "@rmsminiproject1");

        SMTPServer.EnableSsl = true;

        try
        {

            SMTPServer.Send(MyMailMessage);
            Response.Write("<script>alert('success ')</script>");








        }

        catch (Exception ex)
        {

            // string msg = "Hi , your salary has ben credited Application  has been for";
            // SendSMS("8078296466", msg);




        }


    }




    }
    
    
