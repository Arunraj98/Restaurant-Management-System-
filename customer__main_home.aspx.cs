using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customer_bakentouch_home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
    protected void ImageButton7_Click1(object sender, ImageClickEventArgs e)
    {
        string wid  = "Food grains";

        Response.Redirect("~/customer_home.aspx?wid="+wid);


    }
    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {
        string wid = "Household";
        Response.Redirect("~/customer_home.aspx?wid=" + wid);


    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        string wid = "Snacks";

        Response.Redirect("~/customer_home.aspx?wid=" + wid);


    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        string wid = "Vegetable";
        Response.Redirect("~/customer_home.aspx?wid=" + wid);




    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        string wid = "Baby care";

        Response.Redirect("~/customer_home.aspx?wid=" + wid);





    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string wid = "Beauty";

        Response.Redirect("~/customer_home.aspx?wid=" + wid);





    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string wid = "Egg";
        Response.Redirect("~/customer_home.aspx?wid=" + wid);







    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string wid = "Vegetarian";

        Response.Redirect("~/customer_home.aspx?wid=" + wid);





    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string wid = "Drinks";
        Response.Redirect("~/customer_home.aspx?wid=" + wid);

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string wid = "Non Vegetarian";
        Response.Redirect("~/customer_home.aspx?wid=" + wid);


    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        string wid = "Vegetarian";
        Response.Redirect("~/customer_home.aspx?wid=" + wid);

    }








}