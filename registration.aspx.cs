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




public partial class registration : System.Web.UI.Page
{

    public string ConString = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {


        Random r = new Random();

        string otp = r.Next().ToString().Substring(0, 4);
        string fn = FileUpload1.FileName.ToString();
        string pa = "memberphoto/" + TextBox6.Text + fn;
        FileUpload1.PostedFile.SaveAs(Server.MapPath("memberphoto/" + TextBox6.Text + fn));


        MySqlConnection con = new MySqlConnection(ConString);
        con.Open();



        MySqlCommand cmd = new MySqlCommand("insert into staffregistration(name,dob,gender,address,phone,mailid,qualification,salary,photo) values('" + TextBox1.Text + "','" + TextBox2.Text + "','"+RadioButtonList1.SelectedItem.Text+"','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + '0' + "','" + pa + "')", con);


        int j = cmd.ExecuteNonQuery();

        if (j > 0)
        {
            MySqlCommand cmd1 = new MySqlCommand("insert into login (username,password,role,status)values('" + TextBox6.Text + "','" + otp + "','" + RadioButtonList2.SelectedItem.Text + "','Approved')", con);
            int i = cmd1.ExecuteNonQuery();
            if (i > 0)
            {


                MailMessage MyMailMessage = new MailMessage();


                MyMailMessage.From = new MailAddress("rmsminiproject@gmail.com");

                MyMailMessage.To.Add(TextBox6.Text);

                MyMailMessage.Subject = "Hi " +TextBox1.Text+". Your account details";

                MyMailMessage.Body = "Welcome to Hotel Feast. Your username :" + TextBox6.Text + ",Password :" + otp + ".Your designation is "+RadioButtonList2.SelectedItem.Text;

                MyMailMessage.IsBodyHtml = true;

                SmtpClient SMTPServer = new SmtpClient("smtp.gmail.com");

                SMTPServer.Port = 587;

                SMTPServer.Credentials = new System.Net.NetworkCredential("rmsminiproject@gmail.com", "@rmsminiproject1");
                SMTPServer.EnableSsl = true;

                try
                {










                    SMTPServer.Send(MyMailMessage);
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    TextBox6.Text = "";
                    Response.Write("<script>alert('success ')</script>");








                }

                catch (Exception ex)
                {

                    // string msg = "Hi , your salary has ben credited Application  has been for";
                    // SendSMS("8078296466", msg);




                }








            } con.Close();





        }
    }
}