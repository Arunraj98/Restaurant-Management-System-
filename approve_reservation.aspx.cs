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




public partial class approve_design : System.Web.UI.Page
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
        MySqlDataAdapter adapt = new MySqlDataAdapter("SELECT theme.menuid,customerregisration.name,theme.photo,theme.quantity,theme.words_on_cake,theme.functiondate,theme.time,theme.customerid,theme.date,theme.status,theme.amount,theme.name,theme.address,theme.phone,theme.paymentstatus,theme.paymentmode,theme.amount FROM theme INNER JOIN customerregisration ON theme.customerid = customerregisration.emailid where theme.status='' or theme.status='Not approved' or theme.status='Approved' or theme.status='Started' or theme.status='Finished' or theme.status='Cost assigned' or theme.status='Ready to deliver' or theme.status='Cost approved' or theme.status='Delivered and paid'", con);
        con.Open();
        adapt.Fill(dt);
        con.Close();
       
        GridView2.DataSource = dt;
        GridView2.DataBind();





    }



    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
 
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex;
        this.BindGrid();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView2.Rows[e.RowIndex];
        int did=Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);

        // string name = (row.FindControl("txt_name") as TextBox).Text;
        // string address = (row.FindControl("txt_address")as TextBox).Text;
        //string place = (row.FindControl("txt_place") as TextBox).Text;
        // string phoneno = (row.FindControl("txt_phone") as TextBox).Text;

        string username = (row.FindControl("email") as Label).Text;
        string status = (row.FindControl("DropStatus") as DropDownList).Text;
       string date = (row.FindControl("d") as Label).Text;

        string query = "UPDATE theme SET status=@status WHERE menuid=@did";

        using (MySqlConnection con = new MySqlConnection(ConString))
        {
            using (MySqlCommand cmd = new MySqlCommand(query))
            {


                cmd.Parameters.AddWithValue("@did", did);
                cmd.Parameters.AddWithValue("@status", status);
               // cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();





                MailMessage MyMailMessage = new MailMessage();

                MyMailMessage.From = new MailAddress("rmsminiproject@gmail.com");


                MyMailMessage.To.Add(username);

                MyMailMessage.Subject = " Your theme status details";

                MyMailMessage.Body = "Status of Your theme with booking no:"+did+ ", submitted for date "+date+" is "+status+".If we approved your theme then we will inform you about cost of your theme soon" ;

                MyMailMessage.IsBodyHtml = true;

                SmtpClient SMTPServer = new SmtpClient("smtp.gmail.com");

                SMTPServer.Port = 587;

                SMTPServer.Credentials = new System.Net.NetworkCredential("rmsminiproject@gmail.com", "@rmsminiproject1");

                SMTPServer.EnableSsl = true;

                try
                {

                    SMTPServer.Send(MyMailMessage);
                    Response.Write("<script>alert('success!! Status updated ')</script>");








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
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
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
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        this.BindGrid();

   
    }
}