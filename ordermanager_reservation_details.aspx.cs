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

public partial class ordermanager_reservation_details : System.Web.UI.Page
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
        MySqlDataAdapter adapt = new MySqlDataAdapter("SELECT reservation.payid,reservation.hours,reservation.rdate,reservation.no_of_seats,reservation.type,reservation.time,reservation.date,reservation.bstatus,reservation.amount,reservation.name,reservation.phone,reservation.status,reservation.mode,reservation.email FROM reservation", con);
        con.Open();
        adapt.Fill(dt);
        con.Close();

        GridView2.DataSource = dt;
        GridView2.DataBind();





    }


    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        this.BindGrid();

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
        int did = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);

        string name = (row.FindControl("email") as Label).Text;
        // string address = (row.FindControl("txt_address")as TextBox).Text;
        //string place = (row.FindControl("txt_place") as TextBox).Text;
        string date = (row.FindControl("d") as Label).Text;

        // string username = (row.FindControl("lbl_email") as Label).Text;
        int amount = Convert.ToInt16((row.FindControl("amount") as Label).Text) / 2;
        Session["amount"] = amount;
        Session["designname"] = (row.FindControl("tid") as Label).Text;
        Session["date"] = date.ToString();
        // string amount = (row.FindControl("TextBox1") as TextBox).Text;
        Session["email"] = name.ToString();



        string status = (row.FindControl("DropStatus") as DropDownList).Text;




        MySqlConnection con23 = new MySqlConnection(ConString);
        con23.Open();
        MySqlCommand cmd23 = new MySqlCommand("select bstatus from reservation where payid='" + did + "'", con23);

        string stat = cmd23.ExecuteScalar().ToString();

        if (stat == "Cancelled")
        {



            Response.Write("<script>alert('Reservation cancelled by customer ')</script>");
        
        
        
        
        
        
        }


        else if (stat == "Confirmed")
        {

            Response.Write("<script>alert('Reservation confirmed by customer')</script>");
        
        
        
        }
        else if (stat == "Confirmed")
        
        {}


        else
        {


            string query = "UPDATE reservation SET bstatus=@status WHERE payid=@did";

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


                    MyMailMessage.To.Add(name);

                    MyMailMessage.Subject = "Reservation details";

                    MyMailMessage.Body = "Your reservation with code" + did + ", submitted for date " + date + " has been " + status + " . If it is available then please pay reservation charge for confirmation of your reservation. Please note that there is no refunding for cancellation of reservation";

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
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }




}