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



using System.Web.UI.WebControls;



public partial class customized_delivery : System.Web.UI.Page
{
   public string ConString = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {



        if (!this.IsPostBack)
        {
            this.BindGrid();
        }
    }
    private void BindGrid()
    {
        DataTable dt = new DataTable();
        MySqlConnection con = new MySqlConnection(ConString);
        MySqlDataAdapter adapt = new MySqlDataAdapter("Select theme.menuid,customerregisration.name,theme.photo,theme.cloth,theme.size,theme.functiondate,theme.time,theme.customerid,theme.date,theme.status,theme.amount,theme.name,theme.address,theme.phone,theme.paymentstatus,theme.paymentmode FROM theme INNER JOIN customerregisration ON theme.customerid = customerregisration.emailid where theme.status='Delivered and paid' or theme.status='Ready to deliver' or theme.status='Cash on delivery' or theme.status='Paid'", con);
        con.Open();
        adapt.Fill(dt);
        con.Close();











        GridView2.DataSource = dt;
        GridView2.DataBind();





    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        this.BindGrid();

    }





     protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
     protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex;
        this.BindGrid();
    }
     protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
     {
         GridViewRow row = GridView2.Rows[e.RowIndex];
         int did = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);

         // string name = (row.FindControl("txt_name") as TextBox).Text;
         // string address = (row.FindControl("txt_address")as TextBox).Text;
         //string place = (row.FindControl("txt_place") as TextBox).Text;
         // string phoneno = (row.FindControl("txt_phone") as TextBox).Text;

         string username = (row.FindControl("email") as Label).Text;
         //string status = (row.FindControl("DropStatus") as DropDownList).Text;
         string amount = (row.FindControl("amount") as Label).Text;
         string date = (row.FindControl("d") as Label).Text;

         string time = (row.FindControl("t") as Label).Text;

         string pm = (row.FindControl("pm") as Label).Text;

         if (pm == "Not Choosed")
         {

            

             MailMessage MyMailMessage = new MailMessage();

             MyMailMessage.From = new MailAddress("rmsminiproject@gmail.com");


             MyMailMessage.To.Add(username);


             MyMailMessage.Subject = "Fashionzone!!! Kindly choose payment.We are going to deliver your product soon";

             MyMailMessage.Body = "Your customized design product  with booking no:" + did + " ordered for " + date + "," + time + " is ready for delivery and please choose payment mode.There is option for online payment .";

             MyMailMessage.IsBodyHtml = true;


             SmtpClient SMTPServer = new SmtpClient("smtp.gmail.com");

             SMTPServer.Port = 587;

             SMTPServer.Credentials = new System.Net.NetworkCredential("rmsminiproject@gmail.com", "@rmsminiproject1");

             SMTPServer.EnableSsl = true;

             try
             {

                 SMTPServer.Send(MyMailMessage);







                 Response.Write("<script>alert('Payment mode not choosed ')</script>");



             }

             catch (Exception ex)
             {

                 // string msg = "Hi , your salary has ben credited Application  has been for";
                 // SendSMS("8078296466", msg);




             }







         
         }
         else
         {

             string query = "UPDATE theme SET status=@status,paymentstatus=@pstatus WHERE menuid=@did";



             using (MySqlConnection con = new MySqlConnection(ConString))
             {
                 using (MySqlCommand cmd = new MySqlCommand(query))
                 {


                     cmd.Parameters.AddWithValue("@did", did);
                     cmd.Parameters.AddWithValue("@pstatus", "Full amount paid");
                     cmd.Parameters.AddWithValue("@status", "Delivered and paid");
                     // cmd.Parameters.AddWithValue("@amount", amount);
                     cmd.Connection = con;
                     con.Open();
                     cmd.ExecuteNonQuery();

                     MySqlConnection con2 = new MySqlConnection(ConString);
                     con2.Open();
                     MySqlCommand cmd2 = new MySqlCommand("select name from customerregisration where emailid='" + username + "'", con2);

                     string pa1 = cmd2.ExecuteScalar().ToString();



                     con2.Close();




                     MailMessage MyMailMessage = new MailMessage();
                     MailMessage MyMailMessage1 = new MailMessage();
                     MyMailMessage.From = new MailAddress("rmsminiproject@gmail.com");
                     MyMailMessage1.From = new MailAddress("rmsminiproject@gmail.com");

                     MyMailMessage.To.Add(username);
                     MyMailMessage1.To.Add("rmsminiproject@gmail.com");

                     MyMailMessage.Subject = "Hi " + pa1 + " .Your customized design delivery  details";
                     MyMailMessage1.Subject = " Fashionzone Delivery Details";
                     MyMailMessage.Body = "Your customized design  with booking no:" + did + " ordered for " + date + "," + time + "delivered and paid full amount.Thank You for choosing us.";
                     MyMailMessage1.Body = "Customised design  with booking no:" + did + ". delivered and paid full amount.Login and check for more details";
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
                         Response.Write("<script>alert('success!Delivery status updated ')</script>");








                     }

                     catch (Exception ex)
                     {

                         // string msg = "Hi , your salary has ben credited Application  has been for";
                         // SendSMS("8078296466", msg);




                     }



                     con.Close();
                 }
             }
             GridView2.EditIndex = -1;
             this.BindGrid();
         }
     }
    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.EditIndex = -1;
        this.BindGrid();
    }
    /* protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
     {
         int bno = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
         string query = "DELETE FROM patient_test WHERE booking_no=@Bno";

         using (MySqlConnection con = new MySqlConnection(ConString))
         {
             using (MySqlCommand cmd = new MySqlCommand(query))
             {
                 cmd.Parameters.AddWithValue("@Bno", bno);
                 cmd.Connection = con;
                 con.Open();
                 cmd.ExecuteNonQuery();
                 con.Close();
             }
         }

         this.BindGrid();
     }
     * */
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }








   
    

    
}
