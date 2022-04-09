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

using System.IO;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net;

public partial class product_bouquet_public : System.Web.UI.Page
{
    public string ConString = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        Productcake();
    }


    public void Productcake()
    {
        string query = "select pid,photoname,pname,price,stock,quantity from product where ptype='Vegetarian'";
        MySqlConnection con = new MySqlConnection(ConString);
        MySqlDataAdapter da = new MySqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        repeater2.DataSource = ds;
        repeater2.DataBind();








    }




    protected void repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Response.Write("<script>alert('Create your account ,Login and place your order!!!')</script>");



    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MySqlConnection con = new MySqlConnection(ConString);
        con.Open();


        MySqlCommand cmd = new MySqlCommand("insert into feedback(fname,lname,email,phone,comment,date) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + DateTime.Now + "')", con);


        int j = cmd.ExecuteNonQuery();

        if (j > 0)
        {






            MailMessage MyMailMessage = new MailMessage();

            MyMailMessage.From = new MailAddress("rmsminiproject@gmail.com");


            MyMailMessage.To.Add("rmsminiproject@gmail.com");

            MyMailMessage.Subject = "Feedback alert";

            MyMailMessage.Body = "Feedback message :" + TextBox5.Text + ", For more details login and check!!";

            MyMailMessage.IsBodyHtml = true;

            SmtpClient SMTPServer = new SmtpClient("smtp.gmail.com");

            SMTPServer.Port = 587;

            SMTPServer.Credentials = new System.Net.NetworkCredential("rmsminiproject@gmail.com", "@rmsminiproject1");

            SMTPServer.EnableSsl = true;

            try
            {

                SMTPServer.Send(MyMailMessage);









            }

            catch (Exception ex)
            {

                // string msg = "Hi , your salary has ben credited Application  has been for";
                // SendSMS("8078296466", msg);




            }






            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            Response.Write("<script>alert('Feedback sent successfully  ')</script>");

        }
        con.Close();




    }
}