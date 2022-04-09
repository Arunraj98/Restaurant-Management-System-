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




public partial class Staffdetails : System.Web.UI.Page
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
        MySqlDataAdapter adapt = new MySqlDataAdapter("select staffregistration.staffid,staffregistration.name,staffregistration.dob,staffregistration.gender,staffregistration.address,staffregistration.phone,staffregistration.mailid,staffregistration.qualification,staffregistration.photo,login.role,login.status from staffregistration INNER JOIN login ON staffregistration.qualification=login.username order by staffregistration.staffid ASC", con);
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
       // int did = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);

        // string name = (row.FindControl("txt_name") as TextBox).Text;
        // string address = (row.FindControl("txt_address")as TextBox).Text;
        //string place = (row.FindControl("txt_place") as TextBox).Text;
        // string phoneno = (row.FindControl("txt_phone") as TextBox).Text;

        string username = (row.FindControl("lbl_qualification") as Label).Text;
      string status = (row.FindControl("DropStatus") as DropDownList).Text;
       // string status = (row.FindControl("TextBox1") as TextBox).Text;

        string query = "UPDATE login SET status=@status WHERE username=@uname";

        using (MySqlConnection con = new MySqlConnection(ConString))
        {
            using (MySqlCommand cmd = new MySqlCommand(query))
            {


               // cmd.Parameters.AddWithValue("@did", did);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@uname", username);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
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
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
     {
         int bno = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);
         string query = "DELETE FROM  staffregistration WHERE booking_no=@Bno";

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
      
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}






