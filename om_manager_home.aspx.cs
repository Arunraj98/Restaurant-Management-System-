using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class om_manager_home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

   
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string wid = "Drinks";
        Response.Redirect("~/om_manager_inner_home.aspx?wid=" + wid);

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string wid = "Non Vegetarian";
        Response.Redirect("~/om_manager_inner_home.aspx?wid=" + wid);


    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        string wid = "Vegetarian";
        Response.Redirect("~/om_manager_inner_home.aspx?wid=" + wid);

    }
}