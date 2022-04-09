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

public partial class admin_uber_bucket_sales : System.Web.UI.Page
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
        MySqlDataAdapter adapt = new MySqlDataAdapter("SELECT paymentid,name,email,address,phone,productname,photoname,status,amount,mode,quantity,nos from sales where pcode='" + Session["pid"].ToString() + "' and buystatus='Buy'", con);
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


        MySqlConnection con31 = new MySqlConnection(ConString);
        con31.Open();



        MySqlCommand cmd31 = new MySqlCommand("select status from sales where paymentid='" + did + "'", con31);


        string st = cmd31.ExecuteScalar().ToString();

        con31.Close();










        //string status = (row.FindControl("DropStatus") as DropDownList).Text;
        // string amount = (row.FindControl("TextBox1") as TextBox).Text;


        if (st != "Not paid")
        {

            if (st == "Cancelled")
            {

                Response.Write("<script>alert('Already cancelled')</script>");
            }
            else
            {
                Response.Write("<script>alert('Sorry!!You can't cancel order')</script>");
            }


        }
        else
        {
            string query = "UPDATE sales SET status=@status WHERE paymentid=@did";

            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {


                    cmd.Parameters.AddWithValue("@did", did);
                    cmd.Parameters.AddWithValue("@status", "Cancelled");
                    // cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();




                    BindGrid();







                }
            }
        }

        GridView2.EditIndex = -1;
        this.BindGrid();
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
