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

public partial class production_change_password : System.Web.UI.Page
{
    MySqlDataReader dr;
    public string constring = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string user = Session["user"].ToString();
        MySqlConnection con = new MySqlConnection(constring);

        con.Open();
        MySqlCommand cmd = new MySqlCommand("select username,password,role,status from login where username='" + user + "' and password='" + txt_cpass.Text + "'", con);

        dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            MySqlConnection con1 = new MySqlConnection(constring);

            con1.Open();


            MySqlCommand cmd1 = new MySqlCommand("update login set password='" + TextBox1.Text + "' where username='" + user + "' and password ='" + txt_cpass.Text + "'", con1);
            int i = cmd1.ExecuteNonQuery();
            if (i > 0)
            {
                txt_cpass.Text = "";
                TextBox1.Text = "";
                TextBox2.Text = "";
                Response.Write("<script>alert('Password changed successfully')</script>");
            }
            else
            {


                Response.Write("<script>alert('Failed')</script>");
            }





        }






    }
}