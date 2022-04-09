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




public partial class design : System.Web.UI.Page
{

    public string ConString = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;




    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack) {

            DropDownList8.AppendDataBoundItems = true;
        
        
        }


        
        MySqlConnection con311= new MySqlConnection(ConString);
                con311.Open();



                MySqlCommand cmd311 = new MySqlCommand("select  name from customerregisration where emailid='" + Session["user"].ToString() + "'", con311);

                TextBox5.Text = cmd311.ExecuteScalar().ToString();

                con311.Close();



                MySqlConnection con3111 = new MySqlConnection(ConString);
                con3111.Open();



                MySqlCommand cmd3111 = new MySqlCommand("select  phoneno from customerregisration where emailid='" + Session["user"].ToString() + "'", con3111);

                TextBox4.Text = cmd3111.ExecuteScalar().ToString();

                con3111.Close();








        for (int i = 1; i <= 20; i++)
        {

            DropDownList8.Items.Add(i.ToString());
        }

        for (int i = 1; i <= 5; i++)
        {

            DropDownList2.Items.Add(i.ToString());
        }




    }
    protected void SUBMIT_Click(object sender, EventArgs e)
    {


      
        {
           
            string cust_id = Session["user"].ToString();

            MySqlConnection con1 = new MySqlConnection(ConString);
            con1.Open();


            MySqlConnection con = new MySqlConnection(ConString);
            con.Open();



            


            MySqlCommand cmd = new MySqlCommand("insert into reservation(type,hours,no_of_seats,rdate,time,email,date,bstatus,amount,phone,name,status,mode) values('"+ddltype.SelectedItem.Text+"','"+DropDownList2.SelectedItem.Text+"','" + DropDownList8.SelectedItem.Text + "','" + TextBox1.Text + "','"+TextBox2.Text+"','" + cust_id + "','" + DateTime.Now + "','Pending','"+txttype.Text+"','"+TextBox4.Text+"','"+TextBox5.Text+"','Not Paid','Not paid')", con);


            int j = cmd.ExecuteNonQuery();

            if (j > 0)
            {

                MySqlConnection con31 = new MySqlConnection(ConString);
                con31.Open();



                MySqlCommand cmd31 = new MySqlCommand("select username from login where role='Order management manager'", con31);


                string ad = cmd31.ExecuteScalar().ToString();

                con31.Close();







                MailMessage MyMailMessage = new MailMessage();
                MailMessage MyMailMessage1 = new MailMessage();

                MyMailMessage.From = new MailAddress("rmsminiproject@gmail.com");
                MyMailMessage1.From = new MailAddress("rmsminiproject@gmail.com");

                MyMailMessage.To.Add(ad);
                MyMailMessage1.To.Add(Session["user"].ToString());

                MyMailMessage.Subject = "Hotel Feast, New reservation details ";
                MyMailMessage1.Subject = "Hotel Feast, Your reservation details";
                MyMailMessage1.Body = "Your reservation request for date and time: " + TextBox1.Text + " ," + TextBox2.Text + " has been initiated successfully. Login and check for more details. We will mail you soon regarding availability or unavailability about your reservation. You have to pay reservation charge for confirming the reservation and remaining charge of time spend will be added with your food bill.";
                MyMailMessage.Body = "New reservation details submitted for date and time: " + TextBox1.Text + " ," + TextBox2.Text + " .Login and check for more details";

                MyMailMessage.IsBodyHtml = true;
                MyMailMessage1.IsBodyHtml = true;

                SmtpClient SMTPServer = new SmtpClient("smtp.gmail.com");
                SmtpClient SMTPServer1 = new SmtpClient("smtp.gmail.com");

                SMTPServer.Port = 587;
                SMTPServer1.Port = 587;

                SMTPServer.Credentials = new System.Net.NetworkCredential("rmsminiproject@gmail.com", "@rmsminiproject1");
                SMTPServer1.Credentials = new System.Net.NetworkCredential("rmsminiproject@gmail.com", "@rmsminiproject1");
                SMTPServer.EnableSsl = true;
                SMTPServer1.EnableSsl = true;

                try
                {










                    SMTPServer.Send(MyMailMessage);
                    SMTPServer1.Send(MyMailMessage1);


                    Response.Write("<script>alert('success!!! Submitted your reservation.'" + TextBox2.Text + "' ')</script>");





                }

                catch (Exception ex)
                {

                    // string msg = "Hi , your salary has ben credited Application  has been for";
                    // SendSMS("8078296466", msg);




                }







                

                txttype.Text = "";

                TextBox1.Text = "";

                TextBox2.Text = "";
                TextBox5.Text = "";
                TextBox4.Text = "";
               











                

            }
            con.Close();


        }
    }
   
    
          





         


              


            
            
         
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
    {

        MySqlConnection con3111 = new MySqlConnection(ConString);
        con3111.Open();



        MySqlCommand cmd3111 = new MySqlCommand("select amount from reserve where no_of_seats='"+ DropDownList8.SelectedItem.Text + "'", con3111);

       txttype.Text = cmd3111.ExecuteScalar().ToString();

        con3111.Close();






    }
}