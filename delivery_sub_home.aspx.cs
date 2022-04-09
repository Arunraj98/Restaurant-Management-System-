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

public partial class packing_sub_home : System.Web.UI.Page
{
    public string ConString = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {


        Productbooking();


        if (!IsPostBack)
        {

            Productbookings();
        }

    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string query = "select pid,photoname,pname,price,stock,quantity from product where  pstype ='" + DropDownList1.SelectedValue + "'";
        MySqlConnection con = new MySqlConnection(ConString);
        MySqlDataAdapter da = new MySqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        repeater2.DataSource = ds;
        repeater2.DataBind();



    }
    public void Productbookings()
    {



        MySqlConnection con = new MySqlConnection(ConString);
        MySqlCommand cmd = new MySqlCommand("select distinct(subcat) from subcat where cat='" + Request.QueryString["wid"].ToString() + "'", con);
        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = "subcat";
        DropDownList1.DataValueField = "subcat";

        DropDownList1.DataBind();


    }


    public void Productbooking()
    {


        string query = "select pid,photoname,pname,price,stock,quantity from product where ptype='" + Request.QueryString["wid"].ToString() + "'";
        MySqlConnection con = new MySqlConnection(ConString);
        MySqlDataAdapter da = new MySqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        repeater2.DataSource = ds;
        repeater2.DataBind();








    }




    protected void repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int rowid = (e.Item.ItemIndex);


        HiddenField h = (HiddenField)repeater2.Items[rowid].FindControl("HiddenField1");
        //Response.Write("<script>alert('"+h.Value+"')</script>");

        //Label1.Text = h.Value;
        Session["pd"] = h.Value;

        MySqlConnection con = new MySqlConnection(ConString);
        con.Open();


        MySqlCommand cmd = new MySqlCommand("select stock from product where pid=@p", con);

        cmd.Parameters.AddWithValue("@p", h.Value);

        int s = Convert.ToInt16(cmd.ExecuteScalar().ToString());

        if (s == 0)
        {
            Response.Write("<script>alert('Product out of stock')</script>");
        }
        else
        {
            Response.Redirect("~/payment.aspx");
        }



    }








    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        string query = "select pid,photoname,pname,price,stock,quantity from product where  ptype like '%" + TextBox1.Text + "' or quantity like '%" + TextBox1.Text + "' or pname like '%" + TextBox1.Text + "' or pstype like '" + TextBox1.Text + "%' or quantity like '" + TextBox1.Text + "%' or pname like '" + TextBox1.Text + "%'";

        MySqlConnection con = new MySqlConnection(ConString);
        MySqlDataAdapter da = new MySqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        repeater2.DataSource = ds;
        repeater2.DataBind();






    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

        string query = "select pid,photoname,pname,price,stock,quantity from product where  pstype ='" + DropDownList1.SelectedValue + "'";
        MySqlConnection con = new MySqlConnection(ConString);
        MySqlDataAdapter da = new MySqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        repeater2.DataSource = ds;
        repeater2.DataBind();


    }


}