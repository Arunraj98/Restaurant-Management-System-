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


public partial class customer_registration : System.Web.UI.Page
{
    public string ConString = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            DropDownList2.AppendDataBoundItems = true;

        }


        MySqlConnection con = new MySqlConnection(ConString);
        MySqlCommand cmd = new MySqlCommand("select place from place", con);
        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        DropDownList2.DataSource = dt;
        DropDownList2.DataTextField = "place";
        DropDownList2.DataValueField = "place";
        DropDownList2.DataBind();  
         




    }
    protected void Button1_Click(object sender, EventArgs e)
    {

      




        
        // string otp = r.Next().ToString().Substring(0, 4);
        Random r = new Random();

        string otp = r.Next().ToString().Substring(0, 4);

        MySqlConnection con = new MySqlConnection(ConString);
        con.Open();


        MySqlCommand cmd = new MySqlCommand("insert into  customerregisration(name,address,place,phoneno,emailid) values('" + txtname.Text + "','" + txtadres.Text + "','" + DropDownList2.SelectedItem.Text + "','" + txtphoneno.Text + "','" + txtemailid.Text + "')", con);


        int j = cmd.ExecuteNonQuery();

        if (j > 0)
        {
            MySqlCommand cmd1 = new MySqlCommand("insert into login (username,password,role,status)values('" + txtemailid.Text + "','" +TextBox1.Text + "','customer','Approved')", con);
            int i = cmd1.ExecuteNonQuery();
            if (i > 0)
            {




                MailMessage MyMailMessage = new MailMessage();

                MyMailMessage.From = new MailAddress("rmsminiproject@gmail.com");


                MyMailMessage.To.Add(txtemailid.Text);

                MyMailMessage.Subject = "Hi "+txtname.Text+". Welocme to services of Feast";

                MyMailMessage.Body = "Now you can login and place your order.";

                MyMailMessage.IsBodyHtml = true;

                SmtpClient SMTPServer = new SmtpClient("smtp.gmail.com");

                SMTPServer.Port = 587;

                SMTPServer.Credentials = new System.Net.NetworkCredential("rmsminiproject@gmail.com", "@rmsminiproject1");

                SMTPServer.EnableSsl = true;

                try
                {

                    SMTPServer.Send(MyMailMessage);
                    txtname.Text = "";
                    txtadres.Text = "";
                   
                    txtphoneno.Text = "";
                    txtemailid.Text = "";

                    Response.Write("<script>alert('success ')</script>");









                }

                catch (Exception ex)
                {

                    // string msg = "Hi , your salary has ben credited Application  has been for";
                    // SendSMS("8078296466", msg);




                }






            }
        } con.Close();





    }

    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {

    }





    
}