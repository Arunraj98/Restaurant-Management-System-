using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            Session.Clear();
            Session.Abandon();
        }
        catch (Exception ex)
        {
            Response.Write("<script language=\"javascript\">alert(\"Oops!!!Error\");</script>");
        }

        Session.Abandon();
        Session.Clear();
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count == 0)
            {
        Response.Redirect("~/login.aspx");

            }
        }
        catch (Exception ex)
        {
            Response.Write("<script language=\"javascript\">alert(\"Oops!!!Error\");</script>");
        }
    }
}