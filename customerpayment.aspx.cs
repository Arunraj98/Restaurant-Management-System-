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
public partial class customerpayment : System.Web.UI.Page
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
        MySqlDataAdapter adapt = new MySqlDataAdapter("SELECT theme.menuid,customerregisration.name,theme.customerid,theme.photo,theme.cloth,theme.size, theme.functiondate,theme.date,theme.status,theme.amount,theme.time,theme.address,theme.phone,theme.paymentstatus,theme.paymentmode FROM theme INNER JOIN customerregisration ON theme.customerid = customerregisration.emailid  and theme.customerid='" + Session["user"].ToString() + "' and (theme.status='Finished' or theme.status='Ready to deliver') and paymentmode='Not choosed'", con);
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
        int did = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);

        string name = Session["user"].ToString();
        // string address = (row.FindControl("txt_address")as TextBox).Text;
        //string place = (row.FindControl("txt_place") as TextBox).Text;
        string date = (row.FindControl("fdate") as Label).Text;
        string tm= (row.FindControl("t") as Label).Text;
        // string username = (row.FindControl("lbl_email") as Label).Text;
        string status = (row.FindControl("DropStatus") as DropDownList).Text;

        int amt=Convert.ToInt16((row.FindControl("amount") as Label).Text);


        Session["amount"] = amt;
        Session["designname"]=(row.FindControl("designid") as Label).Text;
        Session["date"] = date.ToString();
        // string amount = (row.FindControl("TextBox1") as TextBox).Text;
        Session["email"] = name.ToString();
        if (status == "Online Payment")
        {







            Response.Redirect("~/Paymentin.aspx");
        }

        if (status == "Cash on delivery")
        {
            string query = "UPDATE theme SET paymentmode=@status WHERE menuid=@did";

            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {


                    cmd.Parameters.AddWithValue("@did", Convert.ToInt32(Session["designname"].ToString()));
                    cmd.Parameters.AddWithValue("@status", "Cash on delivery");
                    // cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MySqlConnection con31 = new MySqlConnection(ConString);
                    con31.Open();


                    MySqlCommand cmd31 = new MySqlCommand("select username from login  where role='Delivery staff'", con31);


                    string nm = cmd31.ExecuteScalar().ToString();

                   
                 
                    {
                        MailMessage MyMailMessage = new MailMessage();

                        MyMailMessage.From = new MailAddress("rmsminiproject@gmail.com");


                        MyMailMessage.To.Add(nm);

                        MyMailMessage.Subject = "New customized design for delivery.";

                        MyMailMessage.Body = "New customer design for delivery with booking no :" + (row.FindControl("designid") as Label).Text + " for date time :" +date+","+tm+".Customer choosed cash on delivery ,so collect  amount of  Rs "+amt;

                        MyMailMessage.IsBodyHtml = true;

                        SmtpClient SMTPServer = new SmtpClient("smtp.gmail.com");

                        SMTPServer.Port = 587;

                        SMTPServer.Credentials = new System.Net.NetworkCredential("rmsminiproject@gmail.com", "@rmsminiproject1");

                        SMTPServer.EnableSsl = true;

                        try
                        {

                            SMTPServer.Send(MyMailMessage);



                            Response.Write("<script>alert('Payment mode updated')</script>");

                           






                        }

                        catch (Exception ex)
                        {

                            // string msg = "Hi , your salary has ben credited Application  has been for";
                            // SendSMS("8078296466", msg);




                        }




















                    }
                }

                GridView2.EditIndex = -1;
                this.BindGrid();
            }

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