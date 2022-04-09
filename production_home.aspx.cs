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

public partial class tailor_home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string wid = "Drinks";
        Response.Redirect("~/production_sub_home.aspx?wid=" + wid);

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string wid = "Non Vegetarian";
        Response.Redirect("~/production_sub_home.aspx?wid=" + wid);


    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        string wid = "Vegetarian";
        Response.Redirect("~/production_sub_home.aspx?wid=" + wid);

    }

}