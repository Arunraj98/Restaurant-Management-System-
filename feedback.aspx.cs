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


public partial class feedback : System.Web.UI.Page
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
        MySqlDataAdapter adapt = new MySqlDataAdapter("select fname,lname,email,phone,comment,date from feedback", con);
        con.Open();
        adapt.Fill(dt);
        con.Close();
        GridView2.DataSource = dt;
        GridView2.DataBind();

    }
}