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


public partial class Changeaddress : System.Web.UI.Page
{
    MySqlDataReader dr;
    public string constring = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

        
        if (!IsPostBack)
        {

            DropDownList2.AppendDataBoundItems = true;

        }

       MySqlConnection con2 = new MySqlConnection(constring);
        con2.Open();
        MySqlCommand cmd2 = new MySqlCommand("select address from customerregisration where emailid='" + Session["user"].ToString() + "'", con2);


        string add1 = cmd2.ExecuteScalar().ToString();

        TextBox1.Text = add1;





        MySqlConnection con = new MySqlConnection(constring);
        MySqlCommand cmd = new MySqlCommand("select place from place", con);
        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        DropDownList2.DataSource = dt;
        DropDownList2.DataTextField = "place";
        DropDownList2.DataValueField = "place";
        DropDownList2.DataBind();  
         




    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string user = Session["user"].ToString();
        MySqlConnection con = new MySqlConnection(constring);

        con.Open();
        MySqlCommand cmd = new MySqlCommand("select username,password,role,status from login where username='" + user + "'", con);

        dr = cmd.ExecuteReader();

        if (dr.Read())
        {

         
        






            MySqlConnection con1 = new MySqlConnection(constring);

            con1.Open();


            MySqlCommand cmd1 = new MySqlCommand("update customerregisration set address='" + txt_cpass.Text + "',place='" + DropDownList2.SelectedItem.Text + "' where emailid='" + user + "'", con1);
            int i = cmd1.ExecuteNonQuery();
            if (i > 0)
            {
                txt_cpass.Text = "";
                
                Response.Write("<script>alert('Address changed successfully')</script>");
            }
            else
            {


                Response.Write("<script>alert('Failed')</script>");
            }





        }






    }
}