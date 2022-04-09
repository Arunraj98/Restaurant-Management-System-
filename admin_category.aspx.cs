using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

using System.IO;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net;


public partial class admin_category : System.Web.UI.Page
{
    public string ConString = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DropDownList1.AppendDataBoundItems = true;
        }


    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string type = DropDownList1.SelectedValue;


        DataTable dt = new DataTable();
        MySqlConnection con = new MySqlConnection(ConString);
        MySqlDataAdapter adapt = new MySqlDataAdapter("select scid,subcat from subcat where cat='" + type + "'", con);
        con.Open();
        adapt.Fill(dt);
        con.Close();
        GridView2.DataSource = dt;
        GridView2.DataBind();

    }

    private void BindGrid()
    {
        string type = DropDownList1.SelectedValue;
        DataTable dt = new DataTable();
        MySqlConnection con = new MySqlConnection(ConString);
        MySqlDataAdapter adapt = new MySqlDataAdapter("select scid,subcat from subcat where cat='" + type + "'", con);
        con.Open();
        adapt.Fill(dt);
        con.Close();
        GridView2.DataSource = dt;
        GridView2.DataBind();


    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

        // string name = (row.FindControl("txt_name") as TextBox).Text;
        // string address = (row.FindControl("txt_address")as TextBox).Text;
        //string place = (row.FindControl("txt_place") as TextBox).Text;
        // string phoneno = (row.FindControl("txt_phone") as TextBox).Text;

        // string username = (row.FindControl("email") as Label).Text;
        // string status = (row.FindControl("DropStatus") as DropDownList).Text;
        string stocks = (row.FindControl("TextBox1") as TextBox).Text;

        string query = "UPDATE subcat SET subcat=@stock WHERE scid=@did";

        using (MySqlConnection con = new MySqlConnection(ConString))
        {
            using (MySqlCommand cmd = new MySqlCommand(query))
            {


                cmd.Parameters.AddWithValue("@did", did);
                //cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@stock", stocks);
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

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
