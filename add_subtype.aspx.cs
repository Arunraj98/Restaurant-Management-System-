using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
public partial class add_subtype : System.Web.UI.Page
{
    public string ConString = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {


            DropDownList1.AppendDataBoundItems = true;



        }




    }
    protected void Button1_Click1(object sender, EventArgs e)
    {



        MySqlConnection con = new MySqlConnection(ConString);
        con.Open();
      

        MySqlCommand cmd = new MySqlCommand("insert into subcat(subcat,cat) values('"+TextBox2.Text+"','"+DropDownList1.SelectedValue+"')", con);


        int j = cmd.ExecuteNonQuery();

        if (j > 0)
        {
            TextBox2.Text = "";
            DropDownList1.Items.Clear();
            DropDownList1.Items.Insert(0, new ListItem("select", ""));
            Response.Write("<script>alert('product sub category added successfully  ')</script>");

        }
        con.Close();



    }
}