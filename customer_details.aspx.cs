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





public partial class approve_client : System.Web.UI.Page
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
        MySqlDataAdapter adapt = new MySqlDataAdapter("select customerregisration.cust_id,name,customerregisration.address,customerregisration.place,customerregisration.phoneno,customerregisration.emailid,login.status FROM login INNER JOIN customerregisration ON login.username = customerregisration.emailid", con);
        con.Open();
        adapt.Fill(dt);
        con.Close();
        GridView2.DataSource = dt;
        GridView2.DataBind();

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
         string uname = (GridView2.DataKeys[e.RowIndex].Values[0]).ToString();

       // string name = (row.FindControl("txt_name") as TextBox).Text;
       // string address = (row.FindControl("txt_address")as TextBox).Text;
        //string place = (row.FindControl("txt_place") as TextBox).Text;
       // string phoneno = (row.FindControl("txt_phone") as TextBox).Text;

       // string username = (row.FindControl("lbl_email") as Label).Text;
        string status = (row.FindControl("DropStatus") as DropDownList).Text;
        
        string query = "UPDATE login SET status=@status WHERE username=@uname";

        using (MySqlConnection con = new MySqlConnection(ConString))
        {
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                
                
                cmd.Parameters.AddWithValue("@uname",uname);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
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
  protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      GridViewRow row = GridView2.Rows[e.RowIndex];
         string uname = (GridView2.DataKeys[e.RowIndex].Values[0]).ToString();

        int bno = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);
        string query = "DELETE from customerregisration WHERE username=@uname";

        using (MySqlConnection con = new MySqlConnection(ConString))
        {
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                cmd.Parameters.AddWithValue("@username",uname);
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
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView2.PageIndex = e.NewPageIndex;
        this.BindGrid();

    }
}


   

   


